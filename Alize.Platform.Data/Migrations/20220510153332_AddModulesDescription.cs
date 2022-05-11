using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddModulesDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"),
                column: "Description",
                value: "Permite la visualización de toso los registros de operaciones realizadas sobre la base de datos");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"),
                column: "Description",
                value: "Permite la gestión de alertas");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"),
                column: "Description",
                value: "Permite la gestión de usuarios");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"),
                column: "Description",
                value: "Permite la gestión de empresas");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"),
                column: "Description",
                value: "Permite la visualización de las operaciones de los usuarios en la plataforma");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"),
                column: "Description",
                value: "Permite la gestión de módulos");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "Description",
                value: "Permite la gestión de grupos de usuarios");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"),
                column: "Description",
                value: "Permite la gestión de aplicaciones (consultas)");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"),
                column: "Description",
                value: "Permite la visualización de KPI y parámetros de interés para el usuario");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae49dbc2-e899-4003-9ea8-0e0471f638d6"),
                column: "Description",
                value: "Información de ayuda sobre la plataforma Alize");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"),
                column: "Description",
                value: "Permite la visualización de consultas de la empresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "fd65cba4-e39a-47d3-9a10-77aef323568d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "ce24b69e-0429-4d06-916b-4d3df253d513");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "5eb73cbc-0a19-4200-9183-d62d6c4ac61e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "b08f5e4e-f3e6-4567-bfed-626e39ee68a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "d11072d1-c76b-4e98-96d1-5e2767317853");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "122bb245-d2e0-436e-aa24-c2991168060c", "AQAAAAEAACcQAAAAEFZsOArSF6qibN+r67x/2aAWP0e7KTJuyDx84vcoOFr3qR6eR3K2lQPlWDJvLh2rsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a13c773f-177e-4c6a-af64-98e6d1dbde4f", "AQAAAAEAACcQAAAAEPu+D+muynR7GTgwXV6qSXOLHoqs0UgcGBvbgh7Co1EKPG4rKjumFksm4iOJVJUxyQ==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae49dbc2-e899-4003-9ea8-0e0471f638d6"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"),
                column: "Description",
                value: "");
        }
    }
}
