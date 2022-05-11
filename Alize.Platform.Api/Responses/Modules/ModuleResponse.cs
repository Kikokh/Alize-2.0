namespace Alize.Platform.Api.Responses.Modules
{
    public class ModuleResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public string ModuleGroup { get; set; }
    }
}
