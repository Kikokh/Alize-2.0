using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Core.Models
{
    public class Blockchain
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ApiUrl { get; set; }

        public string? RootUserName { get; set; }

        public string? RootEncryptedPassword { get; set; }
    }
}
