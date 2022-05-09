using Alize.Platform.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Alize.Platform.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public SecurityService(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task SetUserRoleAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException(userId);
            var role = await _roleManager.FindByIdAsync(roleId) ?? throw new KeyNotFoundException(roleId);

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<string> LoginUserWithEmail(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, password))
                throw new UnauthorizedAccessException();

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, roles.Single())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task UpdateUserPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException(userId);

            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, newPassword);
        }

        public async Task UpdateUserPasswordAsync(Guid userId, string newPassword) => await this.UpdateUserPasswordAsync(userId.ToString(), newPassword);

        public async Task<IEnumerable<User>> GetUsersAsync() => await _userManager.Users.ToListAsync();

        public async Task<User> GetUserAsync(string id) => await _userManager.FindByIdAsync(id);

        public async Task<User> GetUserAsync(Guid id) => await this.GetUserAsync(id.ToString());

        public async Task<User> RegisterUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(user, password);

                if (result.Succeeded)
                {
                    return user;
                }

                await _userManager.DeleteAsync(user);
            }

            throw new ApplicationException();
        }

        public async Task UpdateUserAsync(User user) => await _userManager.UpdateAsync(user);

        public async Task<User> GetUserWithRolesAsync(string guid) => await GetUserWithRolesAsync(Guid.Parse(guid));

        public async Task<User> GetUserWithRolesAsync(Guid guid)
        {
            return await _userManager
                .Users
                .Include(u => u.Roles)
                .SingleAsync(u => u.Id == guid);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleAsync(Guid guid)
        {
            return await _roleManager.Roles.Include(r => r.Modules).SingleOrDefaultAsync(r => r.Id == guid);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleManager.UpdateAsync(role);
        }
    }
}
