using Alize.Platform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class ApplicationCredentialsRepository : IApplicationCredentialsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationCredentialsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationCredentials?> GetApplicationCredentialsAsync(Guid applicationId, Guid blockchainId)
        {
            return await _dbContext
                .ApplicationCredentials
                .Include(x => x.Blockchain)
                .SingleOrDefaultAsync(ac => ac.ApplicationId == applicationId && ac.BlockchainId == blockchainId);
        }
    }
}
