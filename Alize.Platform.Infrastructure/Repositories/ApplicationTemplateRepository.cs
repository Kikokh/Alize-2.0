using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Microsoft.Azure.Cosmos;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class ApplicationTemplateRepository : IApplicationTemplateRepository
    {
        private readonly Container _container;

        public ApplicationTemplateRepository(Container container)
        {
            this._container = container;
        }

        public async Task<ApplicationTemplate?> GetApplicationTemplateAsync()
        {
            try
            {
                var query = _container.GetItemQueryIterator<ApplicationTemplate>(new QueryDefinition($"SELECT * FROM item WHERE item.Type = '{ApplicationItemTypes.ApplicationTemplate}'"));

                var response = await query.ReadNextAsync();

                return response.FirstOrDefault();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<ApplicationTemplate> CreateApplicationTemplateAsync(ApplicationTemplate template)
        {
            template.Id = Guid.NewGuid().ToString();
            var response = await _container.CreateItemAsync(template);

            return response.Resource;
        }

        public async Task DeleteApplicationTemplateAsync()
        {
            var item = await GetApplicationTemplateAsync();
            await _container.DeleteItemAsync<ApplicationTemplate>(item?.Id.ToString(), new PartitionKey(item?.Id.ToString()));
        }
    }
}
