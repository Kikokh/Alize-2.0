using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;

namespace Alize.Platform.Infrastructure.Extensions
{
    public static class BlobStorageExtensions
    {
        public static IServiceCollection InitializeBlobServiceClientInstance(this IServiceCollection services, string connectionString)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);

            return services.AddSingleton(blobServiceClient);
        }
    }
}
