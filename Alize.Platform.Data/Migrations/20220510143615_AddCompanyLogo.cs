using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Data.Migrations
{
    public partial class AddCompanyLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "122bb245-d2e0-436e-aa24-c2991168060c", "AQAAAAEAACcQAAAAEFZsOArSF6qibN+r67x/2aAWP0e7KTJuyDx84vcoOFr3qR6eR3K2lQPlWDJvLh2rsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), "a13c773f-177e-4c6a-af64-98e6d1dbde4f", "AQAAAAEAACcQAAAAEPu+D+muynR7GTgwXV6qSXOLHoqs0UgcGBvbgh7Co1EKPG4rKjumFksm4iOJVJUxyQ==" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"),
                column: "Logo",
                value: "data:image/png;base64,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");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Logo",
                table: "Companies",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "5b64f86c-2c00-4691-8fb5-035d9a9929e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "d272446e-5df2-4b29-9ee2-177207eaca2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "de7169f8-72b1-4ddc-9c71-68e180f08d6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "362df50d-71be-4d04-ab47-9d2c2ab79a4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "ca223330-fe8e-48b2-9b4f-752e5a9d8f08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "110e797b-39a5-4985-bf1d-5e555daa18af", "AQAAAAEAACcQAAAAED0C7qbMitWL5AEmuul9yjzQEyBm4JbUxGprTmzx9EeU6nHgcStrwMQNlr5RUdJ0gQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "ab2a9924-c540-4316-a1ce-3acc1b3e1fe4", "AQAAAAEAACcQAAAAEAMeKHDMeBvz/+0JSY8WkarhOdKyfxYKHaKhovI6bAWwM1JtIMe3DAbSrxoq9UZNmA==" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"),
                column: "Logo",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
