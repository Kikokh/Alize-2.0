using Alize.Platform.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(s => s.Applications)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "ApplicationUser",
                    j => j
                        .HasOne<Application>()
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_ApplicationUser_Applications_ApplicationId")
                        .OnDelete(DeleteBehavior.NoAction),
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ApplicationUser_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                );

            SeedUsersAndRoles(builder);
        }

        private void SeedUsersAndRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"), Name = "User", NormalizedName = "USER" },
                new Role { Id = Guid.Parse("caddad05-120f-48a8-b659-ff4528e5df97"), Name = "CompanyAdmin", NormalizedName = "COMPANYADMIN" },
                new Role { Id = Guid.Parse("33dde250-ddde-42db-a4b9-5a2355082391"), Name = "CompanyUser", NormalizedName = "COMPANYUSER" }

            );

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                    UserName = "testuser",
                    FirstName = "Test",
                    LastName = "User",
                    NormalizedUserName = "TESTUSER",
                    Email = "test@user.com",
                    EmailConfirmed = true,
                    IsActive = true,
                    NormalizedEmail = "TEST@USER.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new User
                {
                    Id = Guid.Parse("1c822965-eb67-4092-9cf7-cf62806d5395"),
                    UserName = "testadmin",
                    FirstName = "Test",
                    LastName = "Admin",
                    Email = "test@admin.com",
                    NormalizedEmail = "TEST@ADMIN.COM",
                    EmailConfirmed = true,
                    IsActive = true,
                    NormalizedUserName = "TESTADMIN",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                    UserId = Guid.Parse("1c822965-eb67-4092-9cf7-cf62806d5395")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    UserId = Guid.Parse("95ada776-f3e1-42db-aa39-382f91b74cd4")
                }
            );
        }
    }
}