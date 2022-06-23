using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alize.Platform.Infrastructure.Extensions
{
    public static class CosmosDbExtensions
    {
        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection InitializeCosmosClientInstance(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var account = configurationSection.GetSection("Account").Value;
            var key = configurationSection.GetSection("Key").Value;
            var client = new CosmosClient(account, key);

            return services.AddSingleton(client);
        }
    }
}
