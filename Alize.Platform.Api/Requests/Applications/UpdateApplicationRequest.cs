using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Applications
{
    public class UpdateApplicationRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public string? DataType { get; set; }
    }
}
