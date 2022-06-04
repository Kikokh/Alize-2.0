using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAssetsAsync(Guid applicationId);
        Task<Asset> CreateAssetAsync(Asset asset);
    }
}