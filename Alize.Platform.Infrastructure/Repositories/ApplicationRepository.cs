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

            if (user.Role.Name == Roles.AdminPro)
                return await _dbContext
                    .Applications
                    .Include(u => u.Company)
                    .ToListAsync();

            if (user.Role.Name == Roles.Distributor)
                return await _dbContext
                    .Applications
                    .Include(u => u.Company)
                    .Where(a => a.CompanyId == user.CompanyId || a.Company.ParentCompanyId == user.CompanyId)
                    .ToListAsync();

            if (user.Role.Name == Roles.Admin)
                return await _dbContext
                    .Applications
                    .Include(u => u.Company)
                    .Where(a => a.CompanyId == user.CompanyId)
                    .ToListAsync();

            return user.Applications;
        }

        public async Task<Application?> GetApplicationForUserAsync(Guid userId, Guid id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Applications)
                .ThenInclude(u => u.Company)
                .Include(u => u.Roles)
                .SingleAsync(u => u.Id == userId);

            if (user.Role.Name == Roles.AdminPro)
                return await _dbContext
                    .Applications
                    .Include(x => x.Company)
                    .SingleOrDefaultAsync(a => a.Id == id);

            if (user.Role.Name == Roles.Distributor)
                return await _dbContext
                    .Applications
                    .Include(x => x.Company)
                    .Where(a => a.CompanyId == user.CompanyId || a.Company.ParentCompanyId == user.CompanyId)
                    .SingleOrDefaultAsync(a => a.Id == id);

            if (user.Role.Name == Roles.Admin)
                return await _dbContext
                    .Applications
                    .Where(a => a.CompanyId == user.CompanyId)
                    .SingleOrDefaultAsync(a => a.Id == id);

            return user.Applications.SingleOrDefault(a => a.Id == id);
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
