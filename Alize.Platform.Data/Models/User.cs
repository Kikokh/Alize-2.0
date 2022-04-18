﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool IsActive { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public DateTime? EntryDate { get; set; }

        public DateTime? LeavingDate { get; set; }

        public Company? Company { get; set; }

        [StringLength(10)]
        public string? Pin { get; set; }

        public ICollection<Role>? Roles { get; set; }

        public ICollection<Application>? Applications { get; set; }
    }
}