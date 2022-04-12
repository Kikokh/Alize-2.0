using Alize.Platform.Data.Models;

namespace Alize.Platform.Data.Repositories
{
    public interface IModuleRepository
    {
        Task<Module> GetModuleAsync(Guid id);
        Task<IEnumerable<Module>> GetModulesAsync();
    }
}