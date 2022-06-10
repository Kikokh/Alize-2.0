using Alize.Platform.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Users
{
    public class UserCreateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }
        
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
