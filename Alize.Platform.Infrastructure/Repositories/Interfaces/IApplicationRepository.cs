using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IApplicationRepository
    {
        Task<Application> AddApplicationAsync(Application application);
        Task DeleteApplicationAsync(Application application);
        Task<Application?> GetApplicationForUserAsync(Guid userId, Guid id);
        Task<IEnumerable<Application>> GetApplicationsForUserAsync(Guid userId);
        Task<Application> UpdateApplicationAsync(Application application);
        Task SetUserApplicationAccessAsync(Guid applicationId, Guid userId, bool canAccess);
    }
}