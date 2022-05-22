using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface ITemplateRespository
    {
        Task<ApplicationTemplate?> GetApplicationTemplateAsync(Guid applicationId);
        Task<ApplicationAssetTemplate?> GetApplicationAssetTemplateAsync(Guid applicationId);
    }
}