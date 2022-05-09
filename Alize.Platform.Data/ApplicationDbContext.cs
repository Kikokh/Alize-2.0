using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            if (options is null) throw new ArgumentNullException(nameof(options));
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

            builder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<IdentityUserRole<Guid>>();

            SeedCompanies(builder);
            var modules = SeedModules(builder);
            var roles = SeedRoles(builder);
            SeedRoleModule(builder, roles, modules);
            var users = SeedUsers(builder);
            SeedUserRoles(builder);
        }

        #region Seeds
        private void SeedCompanies(ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("554bc4f7-46a9-4a87-a52e-6ca79e24986c"),
                    Name = "Xpander",
                    Description = "Spin off tecnológica del grupo KH",
                    IsActive = true,
                    BusinessName = "KH Xpander",
                    Cif = "B02658383",
                    Language = "Español",
                    Email = "sistemas@grupokh.com",
                    PhoneNumber = "961783551",
                    Web = "http://www.khxpander.com",
                    ContactName = "Javier Belarte",
                    Address = @"C\Gregal, 2",
                    City = "Almussafes",
                    Province = "Valencia",
                    Country = "España",
                    GoogleMapsUrl = "",
                    Zip = "46440"
                },
                new Company
                {
                    Id = Guid.Parse("e8528a43-2a9d-44dd-b1c9-e37777ad0644"),
                    Name = "KH Vives",
                    Description = "Empresa especializada en diseñar, desarrollar y producir componentes y servicios para la industria de la automoción",
                    IsActive = true,
                    BusinessName = "",
                    Cif = "B96796644",
                    Language = "Español",
                    Email = "sistemas@grupokh.com",
                    PhoneNumber = "961783551",
                    Web = "https://www.grupokh.com",
                    ContactName = "Javier Gonzalez",
                    Address = @"C\Gregal, 2",
                    City = "Almussafes",
                    Province = "Valencia",
                    Country = "España",
                    GoogleMapsUrl = "",
                    Zip = "46440"

                },
                new Company
                {
                    Id = Guid.Parse("2f3e3858-4a59-4f0a-a54f-1830e47a9dfe"),
                    Name = "Nunsys",
                    Description = "Nunsys es una empresa especializada en la implantación de soluciones integrales de tecnología",
                    IsActive = true,
                    BusinessName = "",
                    Cif = "B97929566",
                    Language = "Español",
                    Email = "contacto@nunsys.com",
                    PhoneNumber = "960500631",
                    Web = "https://www.nunsys.com",
                    ContactName = "Comercial nunsys",
                    Address = "Calle de Gustavo Eiffel 3",
                    City = "Paterna",
                    Province = "Valencia",
                    Country = "España",
                    GoogleMapsUrl = "",
                    Zip = "46980"

                },
                new Company
                {
                    Id = Guid.Parse("f20a5162-ebe9-48d0-92ae-d3cca917fc43"),
                    Name = "Patatas Lázaro",
                    Description = "Comercio al por mayor de frutas y frutos, verduras frescas y hortalizas",
                    IsActive = true,
                    BusinessName = "",
                    Cif = "",
                    Language = "Español",
                    Email = "",
                    PhoneNumber = "",
                    Web = "",
                    ContactName = "",
                    Address = "",
                    City = "",
                    Province = "",
                    Country = "",
                    GoogleMapsUrl = "",
                    Zip = ""

                }
            );
        }
        private ICollection<Module> SeedModules(ModelBuilder builder)
        {
            var modules = new List<Module>()
            {
                new Module
                {
                    Id = Guid.Parse("a8befaf9-807a-4f7d-aad2-9380f79bc364"),
                    Name = Constants.Modules.Applications,
                    Description = "",
                    ModuleGroup = ModuleGroups.Administration
                },
                new Module
                {
                    Id = Guid.Parse("4112d229-b379-447e-bf37-fb57dd19d5d8"),
                    Name = Constants.Modules.Companies,
                    Description = "",
                    ModuleGroup = ModuleGroups.Administration
                },
                new Module
                {
                    Id = Guid.Parse("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                    Name = Constants.Modules.Groups,
                    Description = "",
                    ModuleGroup = ModuleGroups.Administration
                },
                new Module
                {
                    Id = Guid.Parse("87da1e2c-f36e-4490-bfc8-e75fff9b5510"),
                    Name = Constants.Modules.ModuleAdmin,
                    Description = "",
                    ModuleGroup = ModuleGroups.Administration
                },
                new Module
                {
                    Id = Guid.Parse("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"),
                    Name = Constants.Modules.Users,
                    Description = "",
                    ModuleGroup = ModuleGroups.Administration
                },
                new Module
                {
                    Id = Guid.Parse("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"),
                    Name = Constants.Modules.Alerts,
                    Description = "",
                    ModuleGroup = ModuleGroups.Management
                },
                new Module
                {
                    Id = Guid.Parse("da12c25e-ea5c-4867-a0c4-e82746010507"),
                    Name = Constants.Modules.Queries,
                    Description = "",
                    ModuleGroup = ModuleGroups.Management
                },
                new Module
                {
                    Id = Guid.Parse("ab9d236a-0ee4-4b10-b445-96af2db9188e"),
                    Name = Constants.Modules.ControlPanel,
                    Description = "",
                    ModuleGroup = ModuleGroups.Management
                },
                new Module
                {
                    Id = Guid.Parse("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"),
                    Name = Constants.Modules.UserAudit,
                    Description = "",
                    ModuleGroup = ModuleGroups.Reports
                },
                new Module
                {
                    Id = Guid.Parse("0c75b5f5-f868-43b0-9af0-c45442d9479e"),
                    Name = Constants.Modules.TransactionLog,
                    Description = "",
                    ModuleGroup = ModuleGroups.Reports
                },
                new Module
                {
                    Id = Guid.Parse("ae49dbc2-e899-4003-9ea8-0e0471f638d6"),
                    Name = Constants.Modules.Help,
                    Description = "",
                    ModuleGroup = ModuleGroups.Help
                }
            };

            builder.Entity<Module>().HasData(modules);

            return modules;
        }
        private ICollection<Role> SeedRoles(ModelBuilder builder)
        {
            var roles = new List<Role>()
            {
                new Role
                {
                    Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                    Name = Constants.Roles.AdminPro,
                    NormalizedName = Constants.Roles.AdminPro.ToUpper(),
                    Description = "Los administradores pro tienen acceso completo y sin restricciones a la plataforma"
                },
                new Role
                {
                    Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    Name = Constants.Roles.Distributor,
                    NormalizedName = Constants.Roles.Distributor.ToUpper(),
                    Description = "Los distribuidores tienen acceso completo y sin restricciones en su empresa y empresas clientes que haya dado de alta"
                },
                new Role
                {
                    Id = Guid.Parse("caddad05-120f-48a8-b659-ff4528e5df97"),
                    Name = Constants.Roles.Admin,
                    NormalizedName = Constants.Roles.Admin.ToUpper(),
                    Description = "Los administradores tienen acceso completo y sin restricciones dentro de su empresa"
                },
                new Role
                {
                    Id = Guid.Parse("33dde250-ddde-42db-a4b9-5a2355082391"),
                    Name = Constants.Roles.User,
                    NormalizedName = Constants.Roles.User.ToUpper(),
                    Description = "Los usuarios pueden acceder a la mayoria de opciones de la plataforma y no pueden hacer cambios accidentales o intencionados"
                },
                new Role
                {
                    Id = Guid.Parse("33dde740-ddde-42db-a4b9-5a2355082391"),
                    Name = Constants.Roles.Guest,
                    NormalizedName = Constants.Roles.Guest.ToUpper(),
                    Description = "Los invitados tienen el acceso limitado a las consultas que se le han asignado"
                }
            };

            builder.Entity<Role>().HasData(roles);

            return roles;
        }
        private ICollection<User> SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();

            var users = new List<User>()
            {
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
            };

            builder.Entity<User>().HasData(users);

            return users;
        }
        private void SeedRoleModule(ModelBuilder builder, ICollection<Role> roles, ICollection<Module> modules)
        {
            var adminProModules = modules
                .Where(m =>
                    new[]
                    {
                        Constants.Modules.Applications,
                        Constants.Modules.Companies,
                        Constants.Modules.Groups,
                        Constants.Modules.ModuleAdmin,
                        Constants.Modules.Users,
                        Constants.Modules.Alerts,
                        Constants.Modules.Queries,
                        Constants.Modules.ControlPanel,
                        Constants.Modules.UserAudit,
                        Constants.Modules.TransactionLog
                    }.Contains(m.Name)
                ).Select(m => new { ModulesId = m.Id, RolesId = roles.Single(r => r.Name == Constants.Roles.AdminPro).Id });

            var distributorModules = modules
                .Where(m =>
                    new[]
                    {
                        Constants.Modules.Applications,
                        Constants.Modules.Companies,
                        Constants.Modules.Groups,
                        Constants.Modules.ModuleAdmin,
                        Constants.Modules.Users,
                        Constants.Modules.Queries
                    }.Contains(m.Name)
                ).Select(m => new { ModulesId = m.Id, RolesId = roles.Single(r => r.Name == Constants.Roles.Distributor).Id });

            var adminModules = modules
                .Where(m =>
                    new[]
                    {
                        Constants.Modules.Applications,
                        Constants.Modules.Companies,
                        Constants.Modules.Groups,
                        Constants.Modules.ModuleAdmin,
                        Constants.Modules.Users,
                        Constants.Modules.Queries
                    }.Contains(m.Name)
                ).Select(m => new { ModulesId = m.Id, RolesId = roles.Single(r => r.Name == Constants.Roles.Admin).Id });

            var userModules = modules
                .Where(m =>
                    new[]
                    {
                        Constants.Modules.Queries
                    }.Contains(m.Name)
                ).Select(m => new { ModulesId = m.Id, RolesId = roles.Single(r => r.Name == Constants.Roles.User).Id });

            var guestModules = modules
                .Where(m =>
                    new[]
                    {
                        Constants.Modules.Queries
                    }.Contains(m.Name)
                ).Select(m => new { ModulesId = m.Id, RolesId = roles.Single(r => r.Name == Constants.Roles.Guest).Id });

            builder.Entity<Module>()
               .HasMany(p => p.Roles)
               .WithMany(r => r.Modules).UsingEntity(
                    "ModuleRole",
                    j => j.HasData(
                        adminProModules
                        .Concat(distributorModules)
                        .Concat(adminModules)
                        .Concat(userModules)
                        .Concat(guestModules)
                    )
                );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
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
        #endregion Seeds
    }
}