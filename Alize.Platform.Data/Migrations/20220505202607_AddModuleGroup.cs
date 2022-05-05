using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddModuleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ModuleGroup",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ModuleTypeId",
                table: "Modules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "570bc1ad-a383-458d-a6c1-01021387cddf", "Los administradores pro tienen acceso completo y sin restricciones a la plataforma", "Administrador Pro", "ADMINISTRADOR PRO" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "bf9fd20c-d6ae-473f-b89c-7c268c8efb5b", "Los usuarios pueden acceder a la mayoria de opciones de la plataforma y no pueden hacer cambios accidentales o intencionados", "Usuario", "USUARIO" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "9628378a-f5e3-450c-b6b3-33ac4032076f", "Los distribuidores tienen acceso completo y sin restricciones en su empresa y empresas clientes que haya dado de alta", "Distribuidor", "DISTRIBUIDOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "26fd3d10-a3ef-42fc-9336-964f409ab378", "Los administradores tienen acceso completo y sin restricciones dentro de su empresa", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "Name", "NormalizedName", "UserId" },
                values: new object[] { new Guid("33dde740-ddde-42db-a4b9-5a2355082391"), "82fc702f-aeaf-4ce9-aca7-69ae2190d47f", "Los invitados tienen el acceso limitado a las consultas que se le han asignado", true, "Invitado", "INVITADO", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41a7bbbd-b626-4a84-a393-895b933acb6b", "AQAAAAEAACcQAAAAEK/4jwHMRT93/NbPHIlErIiFWibZu2D4xHmq3Npb+F7P77KDUIrpVT9g7nDXyzDcTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fe0b767-2f13-4052-b3eb-ecd97269a576", "AQAAAAEAACcQAAAAEHxh8gSN85bb+0hlYUoWKzQEV/AZ9AaZh5KBtZNONNx7KdysNQgcdi9C7M4FhbUBJQ==" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Activity", "Address", "BusinessName", "Cif", "City", "Comments", "ContactName", "Country", "Description", "Email", "GoogleMapsUrl", "ImageTypeMime", "IsActive", "Language", "Logo", "Name", "ParentCompanyId", "PhoneNumber", "Province", "Web", "Zip" },
                values: new object[,]
                {
                    { new Guid("2f3e3858-4a59-4f0a-a54f-1830e47a9dfe"), null, "Calle de Gustavo Eiffel 3", "", "B97929566", "Paterna", null, "Comercial nunsys", "España", "Nunsys es una empresa especializada en la implantación de soluciones integrales de tecnología", "contacto@nunsys.com", "", null, true, "Español", null, "Nunsys", null, "960500631", "Valencia", "https://www.nunsys.com", "46980" },
                    { new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), null, "C\\Gregal, 2", "KH Xpander", "B02658383", "Almussafes", null, "Javier Belarte", "España", "Spin off tecnológica del grupo KH", "sistemas@grupokh.com", "", null, true, "Español", null, "Xpander", null, "961783551", "Valencia", "http://www.khxpander.com", "46440" },
                    { new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), null, "C\\Gregal, 2", "", "B96796644", "Almussafes", null, "Javier Gonzalez", "España", "Empresa especializada en diseñar, desarrollar y producir componentes y servicios para la industria de la automoción", "sistemas@grupokh.com", "", null, true, "Español", null, "KH Vives", null, "961783551", "Valencia", "https://www.grupokh.com", "46440" },
                    { new Guid("f20a5162-ebe9-48d0-92ae-d3cca917fc43"), null, "", "", "", "", null, "", "", "Comercio al por mayor de frutas y frutos, verduras frescas y hortalizas", "", "", null, true, "Español", null, "Patatas Lázaro", null, "", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "ModuleGroup", "ModuleTypeId", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"), "", "Informes", new Guid("00000000-0000-0000-0000-000000000000"), "Registro transacciones", null },
                    { new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"), "", "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Alertas", null },
                    { new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"), "", "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Usuarios", null },
                    { new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"), "", "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Empresas", null },
                    { new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"), "", "Informes", new Guid("00000000-0000-0000-0000-000000000000"), "Auditoría usuarios", null },
                    { new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"), "", "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Módulos", null },
                    { new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"), "", "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Grupos", null },
                    { new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"), "", "Administración", new Guid("00000000-0000-0000-0000-000000000000"), "Aplicaciones", null },
                    { new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"), "", "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Panel de control", null },
                    { new Guid("ae49dbc2-e899-4003-9ea8-0e0471f638d6"), "", "Ayuda", new Guid("00000000-0000-0000-0000-000000000000"), "Ayuda", null },
                    { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), "", "Management", new Guid("00000000-0000-0000-0000-000000000000"), "Consultas", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2f3e3858-4a59-4f0a-a54f-1830e47a9dfe"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f20a5162-ebe9-48d0-92ae-d3cca917fc43"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("0c75b5f5-f868-43b0-9af0-c45442d9479e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("1254e6da-49d4-4ba5-9cd4-cff7c10f9304"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("31932e4d-00cd-46b2-afb1-a9e9a1464bd8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("4112d229-b379-447e-bf37-fb57dd19d5d8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("57ca62f5-a0ec-4dbd-9e06-cc2904ac944e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("87da1e2c-f36e-4490-bfc8-e75fff9b5510"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("a8befaf9-807a-4f7d-aad2-9380f79bc364"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ab9d236a-0ee4-4b10-b445-96af2db9188e"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("ae49dbc2-e899-4003-9ea8-0e0471f638d6"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"));

            migrationBuilder.DropColumn(
                name: "ModuleGroup",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleTypeId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "30b43580-bdff-4c6e-a810-281ae527c702", "Admin", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "9e816ac9-24d7-4ca4-927d-6b8769d4fabf", "Company User", "CompanyUser", "COMPANYUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "0644d19f-c3f1-4c1a-8f81-f97c72cb27c0", "User", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                columns: new[] { "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "853c12e2-cea5-4ae1-94fc-43cf7951734a", "Company Admin", "CompanyAdmin", "COMPANYADMIN" });

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

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("a3dde250-ddde-42db-a4b9-5a2355082391"), "User Administration", "UserAdministration", null },
                    { new Guid("aaddad05-120f-48a8-b659-ff4528e5df97"), "Module Administration", "ModuleAdministration", null },
                    { new Guid("ac5e174e-3b0e-446f-86af-483d56fd7210"), "Company Administration", "CompanyAdministration", null },
                    { new Guid("ad3de250-d2de-421b-b4c9-5a5355024392"), "Role Administration", "RoleAdministration", null },
                    { new Guid("ae445865-a24d-4543-a6c6-9443d048cdb9"), "Application Administration", "ApplicationAdministration", null }
                });
        }
    }
}
