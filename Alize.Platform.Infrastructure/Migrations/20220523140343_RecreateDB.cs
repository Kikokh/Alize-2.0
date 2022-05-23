using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class RecreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blockchains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockchains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cif = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Web = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTypeMime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Companies_ParentCompanyId",
                        column: x => x.ParentCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModuleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModuleRole",
                columns: table => new
                {
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleRole", x => new { x.ModulesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ModuleRole_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleRole_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockchainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncriptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationCredentials_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationCredentials_Blockchains_BlockchainId",
                        column: x => x.BlockchainId,
                        principalTable: "Blockchains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => new { x.ApplicationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), "78dca994-16a7-4035-85e5-c34417079a94", "Los administradores pro tienen acceso completo y sin restricciones a la plataforma", true, "Administrador Pro", "ADMINISTRADOR PRO" },
                    { new Guid("33dde250-ddde-42db-a4b9-5a2355082391"), "1594f95c-8fc3-4ef2-82fd-16e353558c3f", "Los usuarios pueden acceder a la mayoria de opciones de la plataforma y no pueden hacer cambios accidentales o intencionados", true, "Usuario", "USUARIO" },
                    { new Guid("33dde740-ddde-42db-a4b9-5a2355082391"), "8f892861-79c3-4e25-bc89-a6a07eaf2664", "Los invitados tienen el acceso limitado a las consultas que se le han asignado", true, "Invitado", "INVITADO" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "199eb939-1fb5-42bf-bbd6-4340395f66f6", "Los distribuidores tienen acceso completo y sin restricciones en su empresa y empresas clientes que haya dado de alta", true, "Distribuidor", "DISTRIBUIDOR" },
                    { new Guid("caddad05-120f-48a8-b659-ff4528e5df97"), "0d85fa04-e2b2-4fba-8a38-996ed70a628e", "Los administradores tienen acceso completo y sin restricciones dentro de su empresa", true, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "Blockchains",
                columns: new[] { "Id", "ApiUrl", "Name" },
                values: new object[] { new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "https://api-v22.blockchainfue.com/api/", "FUE" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Activity", "Address", "BusinessName", "Cif", "City", "Comments", "ContactName", "Country", "Description", "Email", "GoogleMapsUrl", "ImageTypeMime", "IsActive", "Language", "Logo", "Name", "ParentCompanyId", "PhoneNumber", "Province", "Web", "Zip" },
                values: new object[,]
                {
                    { new Guid("2f3e3858-4a59-4f0a-a54f-1830e47a9dfe"), null, "Calle de Gustavo Eiffel 3", "", "B97929566", "Paterna", null, "Comercial nunsys", "España", "Nunsys es una empresa especializada en la implantación de soluciones integrales de tecnología", "contacto@nunsys.com", "", null, true, "Español", null, "Nunsys", null, "960500631", "Valencia", "https://www.nunsys.com", "46980" },
                    { new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), null, "C\\Gregal, 2", "KH Xpander", "B02658383", "Almussafes", null, "Javier Belarte", "España", "Spin off tecnológica del grupo KH", "sistemas@grupokh.com", "", null, true, "Español", "data:image/png;base64,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", "Xpander", null, "961783551", "Valencia", "http://www.khxpander.com", "46440" },
                    { new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), null, "C\\Gregal, 2", "", "B96796644", "Almussafes", null, "Javier Gonzalez", "España", "Empresa especializada en diseñar, desarrollar y producir componentes y servicios para la industria de la automoción", "sistemas@grupokh.com", "", null, true, "Español", null, "KH Vives", null, "961783551", "Valencia", "https://www.grupokh.com", "46440" },
                    { new Guid("f20a5162-ebe9-48d0-92ae-d3cca917fc43"), null, "", "", "", "", null, "", "", "Comercio al por mayor de frutas y frutos, verduras frescas y hortalizas", "", "", null, true, "Español", null, "Patatas Lázaro", null, "", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "IsActive", "ModuleGroup", "ModuleTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"), "Permite la visualización de toso los registros de operaciones realizadas sobre la base de datos", false, "Informes", new Guid("00000000-0000-0000-0000-000000000000"), "Registro transacciones" },
                    { new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"), "Permite la gestión de alertas", false, "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Alertas" },
                    { new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"), "Permite la gestión de usuarios", true, "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Usuarios" },
                    { new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"), "Permite la gestión de empresas", true, "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Empresas" },
                    { new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"), "Permite la visualización de las operaciones de los usuarios en la plataforma", false, "Informes", new Guid("00000000-0000-0000-0000-000000000000"), "Auditoría usuarios" },
                    { new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"), "Permite la gestión de módulos", true, "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Módulos" },
                    { new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"), "Permite la gestión de grupos de usuarios", true, "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Grupos" },
                    { new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"), "Permite la gestión de aplicaciones (consultas)", true, "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Aplicaciones" },
                    { new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"), "Permite la visualización de KPI y parámetros de interés para el usuario", false, "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Panel de control" },
                    { new Guid("ae49dbc2-e899-4003-9ea8-0e0471f638d6"), "Información de ayuda sobre la plataforma Alize", false, "Ayuda", new Guid("00000000-0000-0000-0000-000000000000"), "Ayuda" },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), "Permite la visualización de consultas de la empresa", true, "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Consultas" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), new DateTime(2022, 5, 23, 11, 3, 42, 804, DateTimeKind.Local).AddTicks(8935), "Registro planes de control sistema mapex", true, "Calidad mapex" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EntryDate", "FirstName", "IsActive", "LastName", "LeavingDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"), 0, new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "8ef14a4a-aa37-441a-9a18-45c33a12223e", "test@admin.com", true, null, "Test", true, "Admin", null, false, null, "TEST@ADMIN.COM", "TESTADMIN", "AQAAAAEAACcQAAAAEPf07Liz170iYOKFppNKKTDnNe4u/NuE0Jp0PvQbwkS2gwA+ruR2xpjtpUhR6xf9nw==", null, false, null, null, false, "testadmin" },
                    { new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"), 0, new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "27be32c3-315c-44f0-b024-fdaaf20edbc1", "test@user.com", true, null, "Test", true, "User", null, false, null, "TEST@USER.COM", "TESTUSER", "AQAAAAEAACcQAAAAENB1g0VVtu0Mu03Ogza+R9XV7St6y7bvlw2GkmarYqOA/oQEOS8T/7iSvurcrHNMlg==", null, false, null, null, false, "testuser" }
                });

            migrationBuilder.InsertData(
                table: "ModuleRole",
                columns: new[] { "ModulesId", "RolesId" },
                values: new object[,]
                {
                    { new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") },
                    { new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") },
                    { new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") },
                    { new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") },
                    { new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") },
                    { new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210") },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("33dde250-ddde-42db-a4b9-5a2355082391") },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("33dde740-ddde-42db-a4b9-5a2355082391") },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("caddad05-120f-48a8-b659-ff4528e5df97") }
                });

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("864d7440-d42e-42e0-9e29-bac987a31028"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "CfDJ8OVxN162SLRJjkJckx9xddOS9DkX9iWy4aWGRwkyP5gC7oh_kce92lm5dY4SXuL6bwrBmizWw7Gui12vSEsMV76wf77IQ7NAG9oTbocm5dMrjLBoh9LrIy2Jxvl2S77Hmg2cJXSzvoL_FzWiSItwdiZBlIvjlqaVNL6BFLOrvTiIc1vd-k9puf8eHr9oQ-BzwiN8E-m6J2sJFh57HfYRAYo", "60ffbe3ef24524680871dc75" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_BlockchainId",
                table: "ApplicationCredentials",
                column: "BlockchainId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyId",
                table: "Applications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_UserId",
                table: "ApplicationUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ParentCompanyId",
                table: "Companies",
                column: "ParentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRole_RolesId",
                table: "ModuleRole",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationCredentials");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ModuleRole");

            migrationBuilder.DropTable(
                name: "Blockchains");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
