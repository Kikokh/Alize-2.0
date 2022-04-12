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

        public async Task<Module> GetModuleAsync(Guid id)
        {
            return await _context.Modules.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            return await _context.Modules.ToListAsync();
        }
    }
}
