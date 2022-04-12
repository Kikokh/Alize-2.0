using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), "cf536a34-9124-4a3e-bef2-5bb37c147be2", "Admin", "ADMIN", null },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "9fc54402-b6c3-4248-ab6e-d18a44c6020b", "User", "USER", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EntryDate", "FirstName", "IsActive", "LastName", "LeavingDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"), 0, null, "58fd67c4-2a74-4a8e-819c-d729cc2c0585", null, false, null, "Test", false, "Admin", null, false, null, null, "TESTADMIN", "AQAAAAEAACcQAAAAEHB/S66C3NhXkRGOCtTMuDTGwS21dvAPG+4CQ4spVfGeSI+EXOk59pcF4wzNVbb5BA==", null, false, null, null, false, "testadmin" },
                    { new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"), 0, null, "118706bc-76fa-4920-bd5e-4d997304c739", null, false, null, "Test", false, "User", null, false, null, null, "TESTUSER", "AQAAAAEAACcQAAAAELfWrwy6Usty2scFhKsDsD7XITxNc7sKxL0y0vB4MqjGahehV/p4H7zIMDqpocRkKA==", null, false, null, null, false, "testuser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"));
        }
    }
}
