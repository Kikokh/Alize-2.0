using Alize.Platform.Data.Models;

namespace Alize.Platform.Services
{
    public interface IBlockChainService
    {
        Task<Asset> GetAssetAsync(Application app, Guid assetId);
        Task<Asset> CreateAssetAsync(Application app, string content);
    }
}