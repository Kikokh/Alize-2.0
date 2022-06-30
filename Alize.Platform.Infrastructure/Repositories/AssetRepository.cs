using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Linq;

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

        public async Task<IEnumerable<Asset>> CreateAssetsAsync(IEnumerable<Asset> assets)
        {
            var tasks = assets.Select(asset => _container.CreateItemAsync(asset));

            var result = await Task.WhenAll(tasks);

            return result.Select(r => r.Resource);
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

        public async Task<AssetsPage> GetAssetsPageAsync(Dictionary<string, string> queries, int pageSize, int pageNumber)
        {
            try
            {
                var queryItems = queries
                    .Where(item => item.Value != null && item.Key != "pageSize" && item.Key != "pageNumber")
                    .Select(item => $"item.data.{item.Key} LIKE '%{item.Value}%'");

                var queryTerm = queryItems.Any() ? $"and ({string.Join(" or ", queryItems)})" : string.Empty;
                var query = new QueryDefinition($"SELECT * FROM item WHERE item.Type = '{ApplicationItemTypes.Asset}' {queryTerm} OFFSET {pageSize*pageNumber} LIMIT {pageSize}");
                var iterator = _container.GetItemQueryIterator<Asset>(query);

                var response = await iterator.ReadNextAsync();

                var totalRecordsIterator = _container.GetItemQueryIterator<int>(new QueryDefinition($"SELECT VALUE COUNT(1) FROM item WHERE item.Type = '{ApplicationItemTypes.Asset}'"));

                var totalRecords = await totalRecordsIterator.ReadNextAsync();
                return new AssetsPage()
                {
                    Assets = response,
                    Total = totalRecords.Single()
                };
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new AssetsPage();
            }
        }

        public async Task DeleteAssetsAsync()
        {
            try
            {
                var query = new QueryDefinition($"SELECT VALUE item.id FROM item WHERE item.Type = '{ApplicationItemTypes.Asset}'");
                var iterator = _container.GetItemQueryIterator<string>(query);

                var ids = await iterator.ReadNextAsync();

                var tasks = ids.Select(id => _container.DeleteItemAsync<Asset>(id, new PartitionKey(id)));

                var result = await Task.WhenAll(tasks);

                return;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
            }
        }
    }
}
