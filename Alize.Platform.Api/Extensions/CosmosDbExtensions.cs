﻿using Alize.Platform.Services;
using Microsoft.Azure.Cosmos;

namespace Alize.Platform.Api.Extensions
{
    public static class CosmosDbExtensions
    {
        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection InitializeCosmosClientInstance(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var databaseName = configurationSection.GetSection("DatabaseName").Value;
            var containerName = configurationSection.GetSection("ContainerName").Value;
            var account = configurationSection.GetSection("Account").Value;
            var key = configurationSection.GetSection("Key").Value;
            var client = new CosmosClient(account, key);
            var cosmosDbService = new CosmosDbService(client, databaseName, containerName);
            var database = client.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();
            database.Database.CreateContainerIfNotExistsAsync(containerName, "/id").GetAwaiter().GetResult();

            return services.AddSingleton<ICosmosDbService>(cosmosDbService);
        }
    }
}
