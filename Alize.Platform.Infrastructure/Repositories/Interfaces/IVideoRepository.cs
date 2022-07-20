
namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IVideoRepository
    {
        Task<Stream> DownloadVideoAsync(Guid applicationId, string assetId);
        Uri GetVideoUri(Guid applicationId, string assetId);
        Task<string> UploadVideoAsync(Guid applicationId, string assetId, Stream fileStream);
    }
}