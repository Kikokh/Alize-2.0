using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class SeedModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "c7160f18-e6f6-4562-9277-ba931da32512");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "44e37170-69f0-4f9c-81ca-51a50bace591");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "25fdf193-2cc3-483f-a1a5-2f43fa77ba8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "31817712-4496-4cc0-84ae-9412ae473b7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "bfab4c27-ee90-4645-9399-37a2da03a702");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8521ea73-98d1-4ba7-a220-775602465627", "AQAAAAEAACcQAAAAENPmUD6FwbFIVxG3cALhigCDdyQR4Tpn05BmGWJReqOyg4AXoVrfvfamD0Isrh77tw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d47940d9-c44d-4a43-b422-c702c66c4849", "AQAAAAEAACcQAAAAEDKNhiDb69oPOyR7TE0a7Z67bq8fyGjN/EBTjKS3Nyk3FdfrOJMKGI3A/Yexvi0+Yg==" });

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

            migrationBuilder.CreateIndex(
                name: "IX_ModuleRole_RolesId",
                table: "ModuleRole",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleRole");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Modules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "570bc1ad-a383-458d-a6c1-01021387cddf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "bf9fd20c-d6ae-473f-b89c-7c268c8efb5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "82fc702f-aeaf-4ce9-aca7-69ae2190d47f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "9628378a-f5e3-450c-b6b3-33ac4032076f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "26fd3d10-a3ef-42fc-9336-964f409ab378");

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
    }
}
