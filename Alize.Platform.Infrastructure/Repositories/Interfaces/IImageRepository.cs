namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IImageRepository
    {
        Task<Stream> DownloadImageAsync(Guid applicationId, string fileName);
        Task<string> UploadImageAsync(Guid applicationId, Stream fileStream, string fileName);
    }
}