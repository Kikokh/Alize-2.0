using Alize.Platform.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests
{
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }
    }
}
