using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class UpdateUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "ba28df09-cf04-463b-84d5-fbb27b3e34ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "44d84dde-4825-44b5-9c02-1e8406797fbe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { new Guid("33dde250-ddde-42db-a4b9-5a2355082391"), "17d21f87-477c-4d8f-b5e3-ea38d73882a6", "CompanyUser", "COMPANYUSER", null },
                    { new Guid("caddad05-120f-48a8-b659-ff4528e5df97"), "92f5c7e9-6487-4e48-b664-6fdac8ab2985", "CompanyAdmin", "COMPANYADMIN", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "7d35d1b4-a360-4143-a32c-45671782a4b7", "test@admin.com", true, true, "TEST@ADMIN.COM", "AQAAAAEAACcQAAAAEP055CkWRFBSvHGSeGuw/1J5IlryP8jNNKDLFj3S9MojlmbckSvN8NMiL97ysfQwuw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "8e93433f-c093-4103-b6dd-5e9c7e29ed9b", "test@user.com", true, true, "TEST@USER.COM", "AQAAAAEAACcQAAAAED4e7bpL7Di1sPYiHzByX7hQMNIO9ZTYgEKqKJ8ibLQx0qMk8nEpaAdGGSYu4jP/GQ==" });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a3dde250-ddde-42db-a4b9-5a2355082391"), null, "UserAdministration" },
                    { new Guid("aaddad05-120f-48a8-b659-ff4528e5df97"), null, "ModuleAdministration" },
                    { new Guid("ac5e174e-3b0e-446f-86af-483d56fd7210"), null, "CompanyAdministration" },
                    { new Guid("ad3de250-d2de-421b-b4c9-5a5355024392"), null, "RoleAdministration" },
                    { new Guid("ae445865-a24d-4543-a6c6-9443d048cdb9"), null, "ApplicationAdministration" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a3dde250-ddde-42db-a4b9-5a2355082391"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("aaddad05-120f-48a8-b659-ff4528e5df97"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ac5e174e-3b0e-446f-86af-483d56fd7210"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ad3de250-d2de-421b-b4c9-5a5355024392"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae445865-a24d-4543-a6c6-9443d048cdb9"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "cf536a34-9124-4a3e-bef2-5bb37c147be2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "9fc54402-b6c3-4248-ab6e-d18a44c6020b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "58fd67c4-2a74-4a8e-819c-d729cc2c0585", null, false, false, null, "AQAAAAEAACcQAAAAEHB/S66C3NhXkRGOCtTMuDTGwS21dvAPG+4CQ4spVfGeSI+EXOk59pcF4wzNVbb5BA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "118706bc-76fa-4920-bd5e-4d997304c739", null, false, false, null, "AQAAAAEAACcQAAAAELfWrwy6Usty2scFhKsDsD7XITxNc7sKxL0y0vB4MqjGahehV/p4H7zIMDqpocRkKA==" });
        }
    }
}
