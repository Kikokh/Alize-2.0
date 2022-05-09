
using Alize.Platform.Data.Models;

namespace Alize.Platform.Services
{
    public interface ISecurityService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleAsync(Guid guid);
        Task<User> GetUserAsync(string id);
        Task<User> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserWithRolesAsync(Guid guid);
        Task<User> GetUserWithRolesAsync(string guid);
        Task<string> LoginUserWithEmail(string email, string password);
        Task<User> RegisterUserAsync(User user, string password);
        Task SetUserRoleAsync(string userId, string roleId);
        Task UpdateUserAsync(User user);
        Task UpdateUserPasswordAsync(Guid userId, string newPassword);
        Task UpdateUserPasswordAsync(string userId, string newPassword);
        Task UpdateRoleAsync(Role role);
    }
}