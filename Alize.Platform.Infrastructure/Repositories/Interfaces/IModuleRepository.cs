using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IModuleRepository
    {
        Task<Module> AddModuleAsync(Module module);
        Task DeleteModuleAsync(Module module);
        Task<Module?> GetModuleAsync(Guid id);
        Task<IEnumerable<Module>> GetModulesAsync();
        Task<Module> UpdateModuleAsync(Module module);
    }
}