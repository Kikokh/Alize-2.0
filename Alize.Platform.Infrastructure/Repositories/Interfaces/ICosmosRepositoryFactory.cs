
using Microsoft.Azure.Cosmos;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface ICosmosRepositoryFactory
    {
        IApplicationTemplateRepository GetApplicationTemplateRepository(Guid applicationId);

        IAssetTemplateRepository GetIAssetTemplateRepository(Guid applicationId);

        IAssetRepository GetAssetRepository(Guid applicationId);

        Task<Container> CreateApplicationContainerAsync(Guid applicationId);        
    }
}