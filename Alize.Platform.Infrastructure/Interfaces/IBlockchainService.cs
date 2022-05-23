using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface IBlockchainService
    {
        Task<IEnumerable<Asset>> GetAssetsAsync(Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1);
        Task<Asset?> GetAssetAsync(string assetId);
        Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(string assetId);
    }
}