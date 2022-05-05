using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Data.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string? Activity { get; set; }

        [StringLength(50)]
        public string? BusinessName { get; set; }

        [Required]
        [StringLength(25)]
        public string? Cif { get; set; }

        [StringLength(250)]
        public string? Comments { get; set; }

        [StringLength(25)]
        public string? Language { get; set; }

        [StringLength(25)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100)]
        [Url]
        public string? Web { get; set; }

        [Required]
        [StringLength(50)]
        public string? ContactName { get; set; }

        //Imagen empresa
        public byte[]? Logo { get; set; }

        [StringLength(50)]
        public string? ImageTypeMime { get; set; }

        //Localización
        [StringLength(50)]
        public string? Address { get; set; }

        [StringLength(5)]
        public string? Zip { get; set; }

        [StringLength(25)]
        public string? City { get; set; }

        [StringLength(25)]
        public string? Province { get; set; }

        [StringLength(25)]
        public string? Country { get; set; }

        [Url]
        public string? GoogleMapsUrl { get; set; }

        public Company? ParentCompany { get; set; }
    }
}
