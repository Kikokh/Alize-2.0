using Alize.Platform.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            return await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync( c => c.Id == id);
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompanyAsync(Company company)
        {
            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}
