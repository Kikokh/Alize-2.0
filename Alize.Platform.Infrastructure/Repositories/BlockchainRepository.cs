using Alize.Platform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class BlockchainRepository : IBlockchainRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlockchainRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blockchain?> GetBlockchainAsync(Guid guid)
        {
            return await _dbContext.Blockchains.SingleOrDefaultAsync(b => b.Id == guid);
        }

        public async Task<IEnumerable<Blockchain>> GetBlockchainsAsync()
        {
            return await _dbContext.Blockchains.ToListAsync();
        }
    }
}
