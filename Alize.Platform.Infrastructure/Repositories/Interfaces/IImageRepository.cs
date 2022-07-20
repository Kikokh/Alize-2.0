namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IImageRepository
    {
        Task<Stream> DownloadImageAsync(Guid applicationId, string assetId);
        Task<string> UploadImageAsync(Guid applicationId, string assetId, Stream fileStream);
    }
}