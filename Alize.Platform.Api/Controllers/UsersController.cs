using Alize.Platform.Api.Requests;
using Alize.Platform.Api.Requests.Users;
using Alize.Platform.Api.Responses;
using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userManager.Users.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
        }

        [HttpGet("Me")]
        public async Task<IActionResult> GetMe()
        {
            var user = HttpContext.User;

            return Ok(new
            {
                Claims = user.Claims.Select(s => new
                {
                    s.Type,
                    s.Value
                }).ToList(),
                user.Identity.Name,
                user.Identity.IsAuthenticated,
                user.Identity.AuthenticationType
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new
            {
                AccessToken = jwt
            });
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                }
                
                await _userManager.DeleteAsync(user);
            }            

            return BadRequest(result.Errors);
        }

        [Authorize(Roles = Roles.Admin )]
        [HttpPost("{id}/Roles")]
        public async Task<IActionResult> AddToRoles(string id, IEnumerable<string> roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles.Where(r => !roles.Contains(r)));
            await _userManager.AddToRolesAsync(user, roles.Where(r => !userRoles.Contains(r)));

            return NoContent();
        }
    }
}
