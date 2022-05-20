using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface IBlockchainService
    {
        Task<IEnumerable<Asset>> GetAssetsAsync(int? pageNumber = default, int? pageSize = default, bool isInverse = false);
        Task<Asset?> GetAssetAsync(string assetId);
        Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(string assetId);
    }
}