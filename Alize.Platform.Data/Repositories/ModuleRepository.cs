using Alize.Platform.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Module> AddModuleAsync(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task DeleteModuleAsync(Module module)
        {
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }

        public async Task<Module?> GetModuleAsync(Guid id)
        {
            return await _context.Modules.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> UpdateModuleAsync(Module module)
        {
            _context.Update(module);
            await _context.SaveChangesAsync();
            return module;
        }
    }
}
