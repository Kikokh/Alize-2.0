using Alize.Platform.Data.Models;
using Alize.Platform.Services.Models;

namespace Alize.Platform.Services
{
    public interface IBlockchainService
    {
        Task<IEnumerable<Asset>> GetAssetsAsync(int? pageNumber = default, int? pageSize = default, bool isInverse = false);
        Task<Asset?> GetAssetAsync(string assetId);
    }
}