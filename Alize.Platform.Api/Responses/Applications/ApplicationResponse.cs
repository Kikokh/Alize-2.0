
using Alize.Platform.Api.Responses.Companies;

namespace Alize.Platform.Api.Responses.Applications
{
    public class ApplicationResponse
  {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public CompanyResponse? Company { get; set; }

        public Guid? CompanyId { get; set; }

        public bool IsActive { get; set; }

        public string? DataType { get; set; }

        public string CompanyName => (Company is null) ? String.Empty : Company.Name;

  }
}
