using Alize.Platform.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await _dbContext.Applications.ToListAsync();
        }

        public async Task<Application> GetApplicationAsync(Guid id)
        {
            return await _dbContext.Applications.FindAsync(id);
        }

        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            _dbContext.Update(application);
            await _dbContext.SaveChangesAsync();
            return application;
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            await _dbContext.Applications.AddAsync(application);
            await _dbContext.SaveChangesAsync();
            return application;
        }

        public async Task DeleteApplicationAsync(Application application)
        {
            _dbContext.Applications.Remove(application);
            await _dbContext.SaveChangesAsync();
        }
    }
}
