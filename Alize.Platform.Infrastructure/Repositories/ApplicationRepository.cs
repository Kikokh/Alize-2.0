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

            switch (user.Role?.Name)
            {
                case Roles.AdminPro:
                    return await _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .ToListAsync();

                case Roles.Distributor:
                    return await _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .Where(a => a.Company != null && (a.CompanyId == user.CompanyId || a.Company.ParentCompanyId == user.CompanyId))
                        .ToListAsync();

                case Roles.Admin:
                    return await _dbContext
                        .Applications
                        .Include(u => u.Company)
                        .Where(a => a.CompanyId == user.CompanyId)
                        .ToListAsync();

                default:
                    return user.Applications;
            }
        }

        public async Task<Application?> GetApplicationForUserAsync(Guid userId, Guid id)
        {
            var applicationsQuery = _dbContext
                        .Applications
                        .Include(u => u.Company);

            var user = await _dbContext.Users
                .Include(u => u.Applications)
                .ThenInclude(u => u.Company)
                .Include(u => u.Roles)
                .ThenInclude(r => r.Modules)
                .SingleAsync(u => u.Id == userId);

            switch (user.Role?.Name)
            {
                case Roles.AdminPro:
                    return await applicationsQuery.SingleOrDefaultAsync(a => a.Id == id);

                case Roles.Distributor:
                    return await applicationsQuery
                        .Where(a => a.CompanyId == user.CompanyId || a.Company.ParentCompanyId == user.CompanyId)
                        .SingleOrDefaultAsync(a => a.Id == id);

                case Roles.Admin:
                    return await applicationsQuery
                        .Include(u => u.Company)
                        .Where(a => a.CompanyId == user.CompanyId)
                        .SingleOrDefaultAsync(a => a.Id == id);

                default:
                    return user.Applications.SingleOrDefault(a => a.Id == id);
            }
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
