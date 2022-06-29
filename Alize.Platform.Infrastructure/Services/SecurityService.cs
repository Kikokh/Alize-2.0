using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Alize.Platform.Core.Constants;

namespace Alize.Platform.Infrastructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IModuleRepository _moduleRepository;

        public SecurityService(UserManager<User> userManager, RoleManager<Role> roleManager, IModuleRepository moduleRepository, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _moduleRepository = moduleRepository;
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

            if (user is null || !user.IsActive || !await _userManager.CheckPasswordAsync(user, password))
                throw new UnauthorizedAccessException();

            var roles = await _userManager.GetRolesAsync(user);

            var modules = await _moduleRepository.GetModulesForRoleAsync(roles.Single());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, roles.Single())
            };

            foreach (var module in modules)
            {
                claims.Add(new Claim("module", module.Name));
            }

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

        public async Task<IEnumerable<User>> GetUserListForUserAsync(Guid userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Roles)
                .SingleAsync(u => u.Id == userId);

            var usersQuery = _userManager.Users
                    .Include(u => u.Applications)
                    .Include(u => u.Company)
                    .Include(u => u.Roles);

            switch (user.Role?.Name)
            {
                case Roles.AdminPro:
                    return await usersQuery.ToListAsync();

                case Roles.Distributor:
                    return await usersQuery
                        .Where(u => u.CompanyId == user.CompanyId || u.Company.ParentCompanyId == user.CompanyId)
                        .ToListAsync();

                case Roles.Admin:
                    return await usersQuery
                        .Where(u => u.CompanyId == user.CompanyId)
                        .ToListAsync();

                default:
                    return new List<User>() { user };
            }
        }

        public async Task<User?> GetUserAsync(string id)
        {
            return await _userManager.Users
                .Include(u => u.Company)
                .Include(u => u.Applications)
                .Include(u => u.Roles)
                .ThenInclude(r => r.Modules)
                .SingleOrDefaultAsync(u => u.Id.ToString() == id);
        }

        public async Task<User?> GetUserAsync(Guid id) => await this.GetUserAsync(id.ToString());

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

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleAsync(Guid guid)
        {
            return await _roleManager.Roles.Include(r => r.Modules).SingleOrDefaultAsync(r => r.Id == guid);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleManager.UpdateAsync(role);
        }

        public bool VerifyRolePermit(string currentRole, string toChangeRole)
        {
            List<string> roles = new List<string>() { Roles.AdminPro.ToLower(), Roles.Distributor.ToLower(), Roles.Admin.ToLower() };
            int indexCurrent = roles.IndexOf(currentRole.ToLower());
            if (indexCurrent < 0) return false;
            int indexChangeRole = roles.IndexOf(toChangeRole);

            if (indexCurrent >= 0 && indexCurrent < indexChangeRole) return false;

            return true;
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}
