using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddApplicationCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "Blockchain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockchain", x => x.Id);
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
                        name: "FK_ApplicationCredentials_Blockchain_BlockchainId",
                        column: x => x.BlockchainId,
                        principalTable: "Blockchain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), "Registro planes de control sistema mapex", true, "Calidad mapex" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "aae9059b-e473-4557-8a88-d215c154d1b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "31aeeb3a-83bc-4608-9cff-7078340d9105");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "c6f8b97a-be68-4948-ad84-6c87736b7b66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "f48eef2d-bae5-4abd-8fce-04463b979daf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "77e7fafe-28a2-41c6-8ad8-0d15f57f8f9b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72a343ea-8b49-4678-88b8-36c6febdab0c", "AQAAAAEAACcQAAAAEO3g3A6UWIsqbgFC/f/opQaE0YYXwMrYotDOVPh9ftML2dsqyRkms4jRRGAH1LeSEA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "370e7deb-bd13-4272-ab27-aa578e74e79f", "AQAAAAEAACcQAAAAEGoIjsBFFW6bfFy4ARDslxs8hxuiiYwsqj2EkNiqgq0TjOSflYdpaN1ZD6FQCu7HHQ==" });

            migrationBuilder.InsertData(
                table: "Blockchain",
                columns: new[] { "Id", "ApiUrl", "Name" },
                values: new object[] { new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "https://api-v22.blockchainfue.com/api/", "FUE" });

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("864d7440-d42e-42e0-9e29-bac987a31028"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "CfDJ8OVxN162SLRJjkJckx9xddOS9DkX9iWy4aWGRwkyP5gC7oh_kce92lm5dY4SXuL6bwrBmizWw7Gui12vSEsMV76wf77IQ7NAG9oTbocm5dMrjLBoh9LrIy2Jxvl2S77Hmg2cJXSzvoL_FzWiSItwdiZBlIvjlqaVNL6BFLOrvTiIc1vd-k9puf8eHr9oQ-BzwiN8E-m6J2sJFh57HfYRAYo", "60ffbe3ef24524680871dc75" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_BlockchainId",
                table: "ApplicationCredentials",
                column: "BlockchainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationCredentials");

            migrationBuilder.DropTable(
                name: "Blockchain");

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"));

            migrationBuilder.AddColumn<string>(
                name: "ApiId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
