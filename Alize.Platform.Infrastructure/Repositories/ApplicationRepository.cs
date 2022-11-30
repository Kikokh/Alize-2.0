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

        public async Task<IEnumerable<Application>> GetApplicationsForUserAsync(Guid userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.Applications)
                .ThenInclude(u => u.Company)
                .Include(u => u.Roles)
                .ThenInclude(r => r.Modules)
                .SingleAsync(u => u.Id == userId);

            return user.Role?.Name switch
            {
                Roles.AdminPro => await _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .ToListAsync(),
                Roles.Admin => await _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .Where(a => a.CompanyId == user.CompanyId)
                        .ToListAsync(),
                _ => user.Applications
            };
        }

        public async Task<Application?> GetApplicationForUserAsync(Guid userId, Guid id)
        {
            var applicationsQuery = _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .Include(a => a.ApplicationCredentials)
                            .ThenInclude(a => a.Blockchain);

            var user = await _dbContext.Users
                .Include(u => u.Roles)              
                .SingleAsync(u => u.Id == userId);

            return user.Role?.Name switch
            {
                Roles.AdminPro => await applicationsQuery.SingleOrDefaultAsync(a => a.Id == id),
                Roles.Admin => await applicationsQuery
                        .Where(a => a.CompanyId == user.CompanyId)
                        .SingleOrDefaultAsync(a => a.Id == id),
                _ => await applicationsQuery.SingleOrDefaultAsync(a => a.Id == id && a.Users!.Contains(user))
            };
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

        public async Task SetUserApplicationAccessAsync(Guid applicationId, Guid userId, bool canAccess)
        {
            var user = await _dbContext.Users
                .Include(u => u.Applications)
                .SingleAsync(u => u.Id == userId);

            var application = await _dbContext.Applications
                .SingleAsync(u => u.Id == applicationId);

            if (canAccess && !user.Applications.Contains(application))
            {
                user.Applications.Add(application);
            }
            else if (!canAccess && user.Applications.Contains(application))
            {
                user.Applications.Remove(application);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
