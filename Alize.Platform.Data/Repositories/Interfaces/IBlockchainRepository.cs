using Alize.Platform.Data.Models;

namespace Alize.Platform.Data.Repositories
{
    public interface IBlockchainRepository
    {
        Task<IEnumerable<Blockchain>> GetBlockchainsAsync();
    }
}