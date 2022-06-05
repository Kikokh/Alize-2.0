using Alize.Platform.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Users
{
    public class UserUpdatePasswordRequest
    {
        [Required]
        [Password]
        public string NewPassword { get; set; }

        [Required]
        [Compare(nameof(NewPassword))]
        [Password]
        public string ConfirmPassword { get; set; }
    }
}
