using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") });

            migrationBuilder.DeleteData(
                table: "ModuleRole",
                keyColumns: new[] { "ModulesId", "RolesId" },
                keyValues: new object[] { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("33dde740-ddde-42db-a4b9-5a2355082391") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"),
                column: "CreationDate",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "33dde250-ddde-42db-a4b9-5a2355082391");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "caddad05-120f-48a8-b659-ff4528e5df97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "Name", "NormalizedName" },
                values: new object[] { new Guid("12dde740-ddde-42db-a4b9-5a2355082391"), "12dde740-ddde-42db-a4b9-5a2355082391", "Los invitados tienen el acceso limitado a las consultas que se le han asignado", true, "Invitado", "INVITADO" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("caddad05-120f-48a8-b659-ff4528e5df97"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") },
                    { new Guid("33dde250-ddde-42db-a4b9-5a2355082391"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c822965-eb67-4092-9cf7-cf62806d5395", "AQAAAAEAACcQAAAAELdtEi/cuHGtublx1maS8chKvM0dL73VD1tTbepvZoVXdWMq1TcehPqVRkMFPkf+3w==", "1c822965-eb67-4092-9cf7-cf62806d5395" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95ada776-f3e1-42db-aa39-382f91b74cd4", "AQAAAAEAACcQAAAAEGdCBA3koHfHYux403xMjGFUZ3neXj2b77TjZA9y7yDfBeZ7CuM60wvnLGNTd5XcLQ==", "95ada776-f3e1-42db-aa39-382f91b74cd4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EntryDate", "FirstName", "IsActive", "LastName", "LeavingDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"), 0, new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "004286d4-a835-45c7-8f36-1f9359d7d955", "test@distributor.com", true, null, "Test", true, "Distributor", null, false, null, "TEST@DISTRIBUTOR.COM", "TESTDESTRIBUTOR", "AQAAAAEAACcQAAAAELW/bMvnrCdI/6BfbhN+mH2P29Ux76M//PvtHimjPwo5ItYYklrMel+xWRz3etFaXA==", null, false, null, "004286d4-a835-45c7-8f36-1f9359d7d955", false, "testdistributor" },
                    { new Guid("840411eb-2f77-4444-8f29-76c094834b56"), 0, new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "840411eb-2f77-4444-8f29-76c094834b56", "test@adminpro.com", true, null, "Test", true, "Admin Pro", null, false, null, "TEST@ADMINPRO.COM", "TESTADMINPRO", "AQAAAAEAACcQAAAAEF2FFS2lwMe3p/6s7A+cqCbui5Nt81ZVjYUjr0WbVfGRr2DSDRjrFfdiSGnUZm9kSg==", null, false, null, "840411eb-2f77-4444-8f29-76c094834b56", false, "testadminpro" },
                    { new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"), 0, new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "b6091148-6b17-4e26-9dc7-97d1b34fb025", "test@guest.com", true, null, "Test", true, "Guest", null, false, null, "TEST@GUEST.COM", "TESTGUEST", "AQAAAAEAACcQAAAAEPoF5SEZf2/lCCRxcOZgFdrOvDVfKcPJKsooByTMYyDaRN7UYRmeq+XVKy1NP8oObA==", null, false, null, "b6091148-6b17-4e26-9dc7-97d1b34fb025", false, "testguest" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"),
                column: "ParentCompanyId",
                value: new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("004286d4-a835-45c7-8f36-1f9359d7d955") },
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("840411eb-2f77-4444-8f29-76c094834b56") },
                    { new Guid("12dde740-ddde-42db-a4b9-5a2355082391"), new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025") }
                });

            migrationBuilder.InsertData(
                table: "ModuleRole",
                columns: new[] { "ModulesId", "RolesId" },
                values: new object[] { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("12dde740-ddde-42db-a4b9-5a2355082391") });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("004286d4-a835-45c7-8f36-1f9359d7d955") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("caddad05-120f-48a8-b659-ff4528e5df97"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("840411eb-2f77-4444-8f29-76c094834b56") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33dde250-ddde-42db-a4b9-5a2355082391"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("12dde740-ddde-42db-a4b9-5a2355082391"), new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025") });

            migrationBuilder.DeleteData(
                table: "ModuleRole",
                keyColumns: new[] { "ModulesId", "RolesId" },
                keyValues: new object[] { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("12dde740-ddde-42db-a4b9-5a2355082391") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12dde740-ddde-42db-a4b9-5a2355082391"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 5, 20, 25, 43, 326, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 5, 20, 25, 43, 326, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "b8f8f013-a014-41be-99ce-b3c7e178628f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "cd177087-d90f-4749-bdf3-55f62c38e8b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "f4069aa7-4339-4e9f-b2f6-4d4a6a793c88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "76648e29-276a-41d5-a6b5-69bd6da722f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "Name", "NormalizedName" },
                values: new object[] { new Guid("33dde740-ddde-42db-a4b9-5a2355082391"), "e9ec5700-5ba8-4275-b3f6-1962c1462105", "Los invitados tienen el acceso limitado a las consultas que se le han asignado", true, "Invitado", "INVITADO" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("1c822965-eb67-4092-9cf7-cf62806d5395") },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e2b7091-bab9-4c23-bea6-89b782dc7267", "AQAAAAEAACcQAAAAECbJDbC+I2cC8rydRj90pp4/P7j6PmGz7E9kWEdKMx0dh/yzVRa/kzB3QYwitBQFNQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d5d21dc-1eaf-40d5-b464-4ba526d1fd9e", "AQAAAAEAACcQAAAAEAQw6+ra0532LTuzH+7SNnp9TmZMXhZfz+yhhMC4Ngsji6B2tcsC47UrEY42G2t6MQ==", null });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"),
                column: "ParentCompanyId",
                value: null);

            migrationBuilder.InsertData(
                table: "ModuleRole",
                columns: new[] { "ModulesId", "RolesId" },
                values: new object[] { new Guid("da12c25e-ea5c-4867-a0c4-e82746010507"), new Guid("33dde740-ddde-42db-a4b9-5a2355082391") });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
