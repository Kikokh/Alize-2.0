
using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface ISecurityService
    {
        Task<IEnumerable<Role>> GetRolesForUserAsync(Guid userId);
        Task<Role?> GetRoleAsync(Guid guid);
        Task<User?> GetUserAsync(string id);
        Task<User?> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUserListForUserAsync(Guid userId);
        Task<string> LoginUserWithEmail(string email, string password);
        Task<User> RegisterUserAsync(User user, Guid roleId, string password);
        Task SetUserRoleAsync(string userId, string roleId);
        Task UpdateUserAsync(User user);
        Task UpdateUserPasswordAsync(User user, string newPassword);
        Task UpdateRoleAsync(Role role);
        bool VerifyRolePermit(string currentRole, string toChangeRole);
        Task DeleteUserAsync(User user);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task RecoverUserPasswordAsync(string email);
        Task ResetUserPasswordAsync(string email, string token, string newPassword);
    }
}