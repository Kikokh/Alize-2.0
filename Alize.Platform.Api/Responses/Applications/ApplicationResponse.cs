namespace Alize.Platform.Api.Responses.Applications
{
    public class ApplicationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? CompanyId { get; set; }
        public bool IsActive { get; set; }
    }
}
