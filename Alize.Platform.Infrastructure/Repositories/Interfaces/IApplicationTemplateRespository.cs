using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IApplicationTemplateRepository
    {
        Task<ApplicationTemplate?> GetApplicationTemplateAsync();
        Task<ApplicationTemplate> CreateApplicationTemplateAsync(ApplicationTemplate template);
        Task DeleteApplicationTemplateAsync();
    }
}