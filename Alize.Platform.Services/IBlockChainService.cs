using Alize.Platform.Data.Models;

namespace Alize.Platform.Services
{
    public interface IBlockChainService
    {
        Task<Asset> GetAssetAsync(Guid assetId);
        Task<Asset> CreateAssetAsync(string content);
    }
}