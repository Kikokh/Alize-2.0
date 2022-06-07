using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Application>> GetApplicationsForUserAsync(User user)
        {
            var userRole = user.Role?.Name;

            return await _dbContext
                    .Companies
                    .Where(c => userRole == Roles.AdminPro || c.Id == user.CompanyId || (userRole == Roles.Distributor && c.ParentCompanyId == user.CompanyId))
                    .SelectMany(c => c.Applications)
                    .Include(x => x.Company)
                    .ToListAsync();
        }

        public async Task<Application?> GetApplicationAsync(Guid id) {
            return await _dbContext.Applications
                .AsNoTracking()
                .Include(x => x.Company)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
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
