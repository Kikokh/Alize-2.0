using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Applications
{
    public class SetApplicationAccessRequest
    {
        [Required]
        public Guid UserId { get; set; }

        public bool CanAccess { get; set; }
    }
}
