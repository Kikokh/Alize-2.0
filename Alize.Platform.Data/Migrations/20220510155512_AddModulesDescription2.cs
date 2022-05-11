using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddModulesDescription2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "18f8cf86-b58a-4c28-890b-28a47bc4351a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "df9994f8-8ff1-4ee1-8a68-2e4ee98fe5f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "d21e14e4-3987-4f0f-84f4-def4b48278aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "92c369a2-787c-47cb-b13d-4d36f34508eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "55f6a923-7285-4073-a70e-2f1d03a9ec47");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cc7553f-eb63-4eda-8016-779816f6357f", "AQAAAAEAACcQAAAAEBKt55ZV1MfRcuBAMd6cfb1OdBsiP4OIQ2QOulcrBTyLuxlrt8BOa2KpJ1dXYsYVjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30ab2544-7b68-4dfd-bc52-540944364d6e", "AQAAAAEAACcQAAAAEIJBrMjQrihXFwEHCB+HX0lL9d0p68fQnzJpEedAFrRW9dPsjAimru6wN8vbCzkOvA==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"),
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "eca5cb9c-9444-46e4-8f91-d81a361cc61b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "baccc80d-d3ec-4835-ab64-cd31257831f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "e988616e-69a2-4693-9794-5aa530362fed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "fdc3c0a6-b162-4f62-a7e3-4698c3f6f154");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "e6fd1eeb-e5bc-4785-99b6-93299f6d0518");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f8d202f-0bdd-4f90-afd4-16abd7233d71", "AQAAAAEAACcQAAAAEIBa4marBpA+YHojlXdVAuwfNjKRrIF1VoxVmm2ofIKqur0zmdFqX3K6ZLt/4e44nA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "641072d7-3578-4023-9bc9-d7e9ea6ba2d8", "AQAAAAEAACcQAAAAEHT/eIpmPUK/D49/q2pKxkAKmTayBaCpFMtnLvb4e7ara8fGfxvFb7eNpw6KChAQ+A==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"),
                column: "IsActive",
                value: false);
        }
    }
}
