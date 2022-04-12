using Alize.Platform.Data.Models;

namespace Alize.Platform.Data.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> AddCompanyAsync(Company company);
        Task<Company> GetCompanyAsync(Guid id);
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(Company company);
    }
}