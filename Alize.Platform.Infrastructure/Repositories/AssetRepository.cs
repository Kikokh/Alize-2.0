using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly Container _container;

        public AssetRepository(Container container)
        {
            this._container = container;
        }

        public async Task<Asset> CreateAssetAsync(Asset asset)
        {
            asset.Id = Guid.NewGuid().ToString();
            var response = await _container.CreateItemAsync(asset);

            return response.Resource;
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync(Guid applicationId)
        {
            try
            {
                var query = _container.GetItemQueryIterator<Asset>(new QueryDefinition($"SELECT * FROM item WHERE item.Type = '{ApplicationItemTypes.Asset}'"));

                var response = await query.ReadNextAsync();

                return response.ToList();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return Enumerable.Empty<Asset>();
            }
        }
    }
}
