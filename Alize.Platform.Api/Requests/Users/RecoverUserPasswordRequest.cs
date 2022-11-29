using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Users
{
    public class RecoverUserPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
