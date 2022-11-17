using Alize.Platform.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Users
{
    public class ResetUserPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [Password]
        public string NewPassword { get; set; }
    }
}
