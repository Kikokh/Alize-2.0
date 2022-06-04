using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class CosmosRepositoryFactory : ICosmosRepositoryFactory
    {
        private readonly Database _database;

        public CosmosRepositoryFactory(CosmosClient dbClient, IConfiguration configuration)
        {
            this._database = dbClient.GetDatabase(configuration["CosmosDb:DatabaseName"]);
        }

        public IApplicationTemplateRepository GetApplicationTemplateRepository(Guid applicationId)
        {
            var container = _database.GetContainer(applicationId.ToString());
            return new ApplicationTemplateRepository(container);
        }

        public IAssetTemplateRepository GetIAssetTemplateRepository(Guid applicationId)
        {
            var container = _database.GetContainer(applicationId.ToString());
            return new AssetTemplateRepository(container);
        }

        public async Task<Container> CreateApplicationContainerAsync(Guid applicationId)
        {
            return await _database.CreateContainerIfNotExistsAsync(applicationId.ToString(), "/id");
        }

        public IAssetRepository GetAssetRepository(Guid applicationId)
        {
            var container = _database.GetContainer(applicationId.ToString());
            return new AssetRepository(container);
        }
    }
}
