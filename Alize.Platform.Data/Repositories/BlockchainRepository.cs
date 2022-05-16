using Alize.Platform.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data.Repositories
{
    public class BlockchainRepository : IBlockchainRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlockchainRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Blockchain>> GetBlockchainsAsync()
        {
            return await _dbContext.Blockchains.ToListAsync();
        }
    }
}
