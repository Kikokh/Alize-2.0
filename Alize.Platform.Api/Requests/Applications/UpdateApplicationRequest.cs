using Alize.Platform.Core.Models;

namespace Alize.Platform.Api.Requests.Applications
{
    public class UpdateApplicationRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid? CompanyId { get; set; }

        public bool IsActive { get; set; }

        public string? ApiId { get; set; }

        public string? ApiKey { get; set; }

        public string? DataType { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
