using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Azure.Cosmos;
using System.Text;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class MediaRepository : IVideoRepository, IImageRepository
    {
        private readonly BlobServiceClient _blobServiceClient;

        public MediaRepository(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadImageAsync(Guid applicationId, string assetId, Stream fileStream) => await UploadMediaAsync(applicationId, assetId, fileStream);

        public async Task<Stream> DownloadImageAsync(Guid applicationId, string assetId) => await DownloadMediaAsync(applicationId, assetId);

        public async Task<Stream> DownloadVideoAsync(Guid applicationId, string assetId) => await DownloadMediaAsync(applicationId, assetId);

        public async Task<string> UploadVideoAsync(Guid applicationId, string assetId, Stream fileStream) => await UploadMediaAsync(applicationId, assetId, fileStream);

        public Uri? GetMediaUri(Guid applicationId, string assetId)
        {
            return _blobServiceClient
                .GetBlobContainerClient(applicationId.ToString())
                .GetBlobClient(assetId)
                .GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTime.UtcNow.AddDays(1));
        }        

        private async Task<Stream> DownloadMediaAsync(Guid applicationId, string assetId)
        {
            var container = _blobServiceClient.GetBlobContainerClient(applicationId.ToString());

            var client = container.GetBlobClient(assetId);

            var stream = await client.DownloadStreamingAsync();

            return stream.Value.Content;
        }

        public Uri GetVideoUri(Guid applicationId, string assetId)
        {
            var container = _blobServiceClient.GetBlobContainerClient(applicationId.ToString());

            var client = container.GetBlobClient(assetId);

            return client.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));
        }

        private async Task<string> UploadMediaAsync(Guid applicationId, string assetId, Stream fileStream)
        {
            var container = _blobServiceClient.GetBlobContainerClient(applicationId.ToString());

            await container.CreateIfNotExistsAsync();

            var response = await container
                .GetBlobClient(assetId)
                .UploadAsync(fileStream);

            var sBuilder = new StringBuilder();

            foreach (var @byte in response.Value.ContentHash)
            {
                sBuilder.Append(@byte.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
