using Azure.Storage.Blobs;
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

        public async Task<string> UploadImageAsync(Guid applicationId, Stream fileStream, string fileName) => await UploadMediaAsync(applicationId, fileStream, fileName);

        public async Task<Stream> DownloadImageAsync(Guid applicationId, string fileName) => await DownloadMediaAsync(applicationId, fileName);

        public async Task<Stream> DownloadVideoAsync(Guid applicationId, string fileName) => await DownloadMediaAsync(applicationId, fileName);

        public async Task<string> UploadVideoAsync(Guid applicationId, Stream fileStream, string fileName) => await UploadMediaAsync(applicationId, fileStream, fileName);

        public Uri? GetMediaUri(Guid applicationId, string fileName)
        {
            return _blobServiceClient
                .GetBlobContainerClient(applicationId.ToString())
                .GetBlobClient(fileName)
                .GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTime.UtcNow.AddDays(1));
        }        

        private async Task<Stream> DownloadMediaAsync(Guid applicationId, string fileName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(applicationId.ToString());

            var client = container.GetBlobClient(fileName);

            var stream = await client.DownloadStreamingAsync();

            return stream.Value.Content;
        }

        private async Task<string> UploadMediaAsync(Guid applicationId, Stream fileStream, string fileName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(applicationId.ToString());

            await container.CreateIfNotExistsAsync();

            var response = await container
                .GetBlobClient(fileName)
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
