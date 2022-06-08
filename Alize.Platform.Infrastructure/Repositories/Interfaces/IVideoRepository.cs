
namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IVideoRepository
    {
        Task<Stream> DownloadVideoAsync(Guid applicationId, string fileName);
        Task<string> UploadVideoAsync(Guid applicationId, Stream fileStream, string fileName);
    }
}