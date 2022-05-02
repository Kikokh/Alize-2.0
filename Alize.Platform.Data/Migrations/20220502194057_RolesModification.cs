using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class RolesModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Modules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                columns: new[] { "ConcurrencyStamp", "Description", "IsActive" },
                values: new object[] { "30b43580-bdff-4c6e-a810-281ae527c702", "Admin", true });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                columns: new[] { "ConcurrencyStamp", "Description", "IsActive" },
                values: new object[] { "9e816ac9-24d7-4ca4-927d-6b8769d4fabf", "Company User", true });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "Description", "IsActive" },
                values: new object[] { "0644d19f-c3f1-4c1a-8f81-f97c72cb27c0", "User", true });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                columns: new[] { "ConcurrencyStamp", "Description", "IsActive" },
                values: new object[] { "853c12e2-cea5-4ae1-94fc-43cf7951734a", "Company Admin", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b256499-690c-4693-9735-cb1868051d4c", "AQAAAAEAACcQAAAAEKJbHtjPgmbVoA7pTNudCQooJSP1LCSqd2MQJrTqkyXmu4/hIm++dtfUJu2wlkrOFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92862b7d-92cb-4ab3-b18b-e571acd297e9", "AQAAAAEAACcQAAAAEPELFZGub9MzOyNG12GV0gmk7NdEsPNbyNxNND2yqFJTMdhKxOChuF4UVBK1HOvolA==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a3dde250-ddde-42db-a4b9-5a2355082391"),
                column: "Description",
                value: "User Administration");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("aaddad05-120f-48a8-b659-ff4528e5df97"),
                column: "Description",
                value: "Module Administration");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ac5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "Description",
                value: "Company Administration");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ad3de250-d2de-421b-b4c9-5a5355024392"),
                column: "Description",
                value: "Role Administration");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "Description",
                value: "Application Administration");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_RoleId",
                table: "Modules",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetRoles_RoleId",
                table: "Modules",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetRoles_RoleId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_RoleId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "ba28df09-cf04-463b-84d5-fbb27b3e34ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "17d21f87-477c-4d8f-b5e3-ea38d73882a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "44d84dde-4825-44b5-9c02-1e8406797fbe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "92f5c7e9-6487-4e48-b664-6fdac8ab2985");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d35d1b4-a360-4143-a32c-45671782a4b7", "AQAAAAEAACcQAAAAEP055CkWRFBSvHGSeGuw/1J5IlryP8jNNKDLFj3S9MojlmbckSvN8NMiL97ysfQwuw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e93433f-c093-4103-b6dd-5e9c7e29ed9b", "AQAAAAEAACcQAAAAED4e7bpL7Di1sPYiHzByX7hQMNIO9ZTYgEKqKJ8ibLQx0qMk8nEpaAdGGSYu4jP/GQ==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a3dde250-ddde-42db-a4b9-5a2355082391"),
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("aaddad05-120f-48a8-b659-ff4528e5df97"),
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ac5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ad3de250-d2de-421b-b4c9-5a5355024392"),
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "Description",
                value: null);
        }
    }
}
