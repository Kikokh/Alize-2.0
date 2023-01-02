using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface IBlockchainService
    {
        Task<AssetsPage?> GetAssetsPageAsync(Guid applicationId, Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1);
        Task<Asset?> GetAssetAsync(Guid applicationId, string assetId);
        Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(Guid applicationId, string assetId);
        Task<IDictionary<string, dynamic>?> GetAssetMetadataAsync(Guid applicationId, string assetId);
        Task UpdateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> metadata);
        Task<ApplicationCredentials> CreateApplicationAsync(Application application);
        Task<IEnumerable<Asset>> GetAssets(Guid applicationId);
        Task<Asset> CreateAssetAsync(Guid applicationId, Asset asset);
        Task<IDictionary<string, dynamic>> CreateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> data);
    }
}