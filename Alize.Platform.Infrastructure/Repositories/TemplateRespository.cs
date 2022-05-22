using Alize.Platform.Core.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class TemplateRespository : ITemplateRespository
    {
        private readonly Container _container;

        public TemplateRespository(CosmosClient dbClient, IConfiguration configuration)
        {
            this._container = dbClient.GetContainer(configuration["CosmosDb:DatabaseName"], configuration["CosmosDb:ContainerName"]);
        }

        public async Task<ApplicationAssetTemplate?> GetApplicationAssetTemplateAsync(Guid applicationId)
        {
            try
            {
                var query = _container.GetItemQueryIterator<ApplicationTemplate>(new QueryDefinition($"SELECT item.AssetTemplate FROM item WHERE item.id = '{applicationId}'"));

                var response = await query.ReadNextAsync();

                return response.Select(c => c.AssetTemplate).SingleOrDefault();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<ApplicationTemplate?> GetApplicationTemplateAsync(Guid applicationId)
        {
            try
            {
                var query = _container.GetItemQueryIterator<ApplicationTemplate>(new QueryDefinition($"SELECT item.Columns FROM item WHERE item.id = '{applicationId}'"));

                var response = await query.ReadNextAsync();

                return response.SingleOrDefault();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }
    }
}
