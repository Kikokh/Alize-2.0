using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Users
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
