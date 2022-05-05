using Alize.Platform.Data.Models;
using Microsoft.Azure.Cosmos;

namespace Alize.Platform.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync<T>(T item) where T : Entity
        {
            await this._container.CreateItemAsync<T>(item, new PartitionKey(item.Id.ToString()));
        }

        public async Task DeleteItemAsync<T>(string id) where T : Entity
        {
            await this._container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task<T> GetItemAsync<T>(string id) where T : Entity
        {
            try
            {
                ItemResponse<T> response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string queryString) where T : Entity
        {
            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync<T>(string id, T item) where T : Entity
        {
            await this._container.UpsertItemAsync<T>(item, new PartitionKey(id));
        }
    }
}
