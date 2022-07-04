using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alize.Platform.Core.Models
{
    public class ApplicationCredentials
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Application))]
        public Guid ApplicationId { get; set; }

        public Application Application { get; set; }

        [ForeignKey(nameof(Blockchain))]
        public Guid BlockchainId { get; set; }

        public Blockchain Blockchain { get; set; }

        public string Username { get; set; }

        public string EncryptedPassword { get; set; }
    }
}
