using Alize.Platform.Api.Requests;
using Alize.Platform.Api.Requests.Users;
using Alize.Platform.Api.Responses;
using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public UsersController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var users = await _securityService.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
        }

        [HttpGet("Me")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMe()
        {
            var user = await _securityService.GetUserAsync(User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _securityService.GetUserAsync(id);

            if (user is null)
                return NotFound();

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
                return Ok(new
                {
                    AccessToken = await _securityService.LoginUserWithEmail(request.Email, request.Password)
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }

        [HttpPost("Register")]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> Register(UserCreateRequest request)
        {
            var user = _mapper.Map<User>(request);

            try
            {
                await _securityService.RegisterUserAsync(user, request.Password);
            }
            catch (ApplicationException)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}/Role")]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetRole(string id, string roleId)
        {
            try
            {
                await _securityService.SetUserRoleAsync(id, roleId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPut("{id}")]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateRequest userUpdate)
        {
            if (id != userUpdate.Id)
                return BadRequest();

            var user = await _securityService.GetUserAsync(id);

            if (user is null)
                return NotFound();

            _mapper.Map(userUpdate, user);

            await _securityService.UpdateUserAsync(user);   

            return NoContent();
        }

        [HttpPut("{id}/Password")]
        [Authorize(Policy = Modules.Users)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserPassword(Guid id, UserUpdatePasswordRequest userPasswordUpdate)
        {
            try
            {
                await _securityService.UpdateUserPasswordAsync(id, userPasswordUpdate.NewPassword);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("Me/Password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCurrentUserPassword(UserUpdatePasswordRequest userPasswordUpdate)
        {
            return await UpdateUserPassword(Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value), userPasswordUpdate);
        }
    }
}
