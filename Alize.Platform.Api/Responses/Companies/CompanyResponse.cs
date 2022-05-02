using Alize.Platform.Data.Models;

namespace Alize.Platform.Api.Responses.Companies
{
    public class CompanyResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string? Activity { get; set; }
        public string? BusinessName { get; set; }
        public string? Cif { get; set; }
        public string? Comments { get; set; }
        public string? Language { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Web { get; set; }
        public string? ContactName { get; set; }
        public byte[]? Logo { get; set; }
        public string? ImageTypeMime { get; set; }
        public string? Address { get; set; }
        public string? Zip { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public string? GoogleMapsUrl { get; set; }
        public Company? ParentCompany { get; set; }
    }
}
