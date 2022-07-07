using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IBlockchainRepository
    {
        Task<IEnumerable<Blockchain>> GetBlockchainsAsync();
        Task<Blockchain?> GetBlockchainAsync(Guid guid);
    }
}