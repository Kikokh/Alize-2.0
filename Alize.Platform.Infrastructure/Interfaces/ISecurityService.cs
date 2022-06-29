
using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface ISecurityService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRoleAsync(Guid guid);
        Task<User?> GetUserAsync(string id);
        Task<User?> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUserListForUserAsync(Guid userId);
        Task<string> LoginUserWithEmail(string email, string password);
        Task<User> RegisterUserAsync(User user, string password);
        Task SetUserRoleAsync(string userId, string roleId);
        Task UpdateUserAsync(User user);
        Task UpdateUserPasswordAsync(Guid userId, string newPassword);
        Task UpdateUserPasswordAsync(string userId, string newPassword);
        Task UpdateRoleAsync(Role role);
        bool VerifyRolePermit(string currentRole, string toChangeRole);
        Task DeleteUserAsync(User user);
    }
}