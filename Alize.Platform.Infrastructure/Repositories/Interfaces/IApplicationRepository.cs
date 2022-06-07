using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IApplicationRepository
    {
        Task<Application> AddApplicationAsync(Application application);
        Task DeleteApplicationAsync(Application application);
        Task<Application?> GetApplicationAsync(Guid id);
        Task<IEnumerable<Application>> GetApplicationsForUserAsync(User user);
        Task<Application> UpdateApplicationAsync(Application application);
    }
}