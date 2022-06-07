using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IAssetTemplateRepository
    {
        Task<AssetTemplate?> GetAssetTemplateAsync();
        Task<AssetTemplate> CreateAssetTemplateAsync(AssetTemplate template);
        Task DeleteAssetTemplateAsync();
    }
}