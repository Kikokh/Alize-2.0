using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAssetsAsync(Guid applicationId);
        Task<Asset> CreateAssetAsync(Asset asset);
        Task<IEnumerable<Asset>> CreateAssetsAsync(IEnumerable<Asset> assets);
        Task<AssetsPage> GetAssetsPageAsync(Dictionary<string, string> queries, int pageSize, int pageNumber);
        Task DeleteAssetsAsync();
    }
}