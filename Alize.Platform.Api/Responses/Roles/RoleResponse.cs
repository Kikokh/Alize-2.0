using Alize.Platform.Api.Responses.Modules;

namespace Alize.Platform.Api.Responses.Roles
{
    public class RoleResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ModuleResponse> Modules { get; set; }
    }
}
