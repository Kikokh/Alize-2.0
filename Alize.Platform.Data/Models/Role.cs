using Microsoft.AspNetCore.Identity;

namespace Alize.Platform.Data.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Module> Modules { get; set; }
    }
}
