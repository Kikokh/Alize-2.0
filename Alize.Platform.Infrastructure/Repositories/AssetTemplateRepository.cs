using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Microsoft.Azure.Cosmos;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class AssetTemplateRepository : IAssetTemplateRepository
    {
        private readonly Container _container;

        public AssetTemplateRepository(Container container)
        {
            this._container = container;
        }       

        public async Task DeleteAssetTemplateAsync()
        {
            var item = await GetAssetTemplateAsync();
            await _container.DeleteItemAsync<AssetTemplate>(item?.Id.ToString(), new PartitionKey(item?.Id.ToString()));
        }

        public async Task<AssetTemplate?> GetAssetTemplateAsync()
        {
            try
            {
                var query = _container.GetItemQueryIterator<AssetTemplate>(new QueryDefinition($"SELECT * FROM item WHERE item.Type = '{ApplicationItemTypes.AssetTemplate}'"));

                var response = await query.ReadNextAsync();

                return response.FirstOrDefault();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }        

        public async Task<AssetTemplate> CreateAssetTemplateAsync(AssetTemplate template)
        {
            template.Id = Guid.NewGuid().ToString();
            var response = await _container.CreateItemAsync(template);

            return response.Resource;
        }
    }
}
