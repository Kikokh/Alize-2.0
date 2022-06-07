using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
