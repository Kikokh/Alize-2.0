using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddBlockchains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationCredentials_Blockchain_BlockchainId",
                table: "ApplicationCredentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blockchain",
                table: "Blockchain");

            migrationBuilder.RenameTable(
                name: "Blockchain",
                newName: "Blockchains");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blockchains",
                table: "Blockchains",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "448c181e-d1c7-474a-8d2a-00c7be53543a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "b533456c-94fe-48e4-b38b-f2780daec71b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "86c867d9-b635-4e8e-a27f-7f1a5330ee7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "6bf0ea09-dbba-463e-9397-a7b74a0fa81a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "3cc2aa14-9cfa-4816-adf4-c80eb34a52a9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0e484c5-c814-4d16-94ed-8e42bc15c425", "AQAAAAEAACcQAAAAEFiWgAVjRsd19P8UgTAP5B+OIu2JyovqPn6Wxd0SQJzl/OQktQSdzzlMWbAeagdrBw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5aeb564c-adfc-498f-a6c4-10ba56a3dc06", "AQAAAAEAACcQAAAAEAfG8nw1UU9TVoKQsgzall5IsnfkgVip/QCSLNBKNvi6/3NJuvDNp+uCQGWwUwLkiQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationCredentials_Blockchains_BlockchainId",
                table: "ApplicationCredentials",
                column: "BlockchainId",
                principalTable: "Blockchains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationCredentials_Blockchains_BlockchainId",
                table: "ApplicationCredentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blockchains",
                table: "Blockchains");

            migrationBuilder.RenameTable(
                name: "Blockchains",
                newName: "Blockchain");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blockchain",
                table: "Blockchain",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationCredentials_Blockchain_BlockchainId",
                table: "ApplicationCredentials",
                column: "BlockchainId",
                principalTable: "Blockchain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
