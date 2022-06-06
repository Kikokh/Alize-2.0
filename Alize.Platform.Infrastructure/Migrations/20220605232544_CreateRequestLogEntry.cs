using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class CreateRequestLogEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLogsEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogsEntries", x => x.Id);
                });

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
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "e9ec5700-5ba8-4275-b3f6-1962c1462105");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e2b7091-bab9-4c23-bea6-89b782dc7267", "AQAAAAEAACcQAAAAECbJDbC+I2cC8rydRj90pp4/P7j6PmGz7E9kWEdKMx0dh/yzVRa/kzB3QYwitBQFNQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d5d21dc-1eaf-40d5-b464-4ba526d1fd9e", "AQAAAAEAACcQAAAAEAQw6+ra0532LTuzH+7SNnp9TmZMXhZfz+yhhMC4Ngsji6B2tcsC47UrEY42G2t6MQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLogsEntries");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 3, 11, 43, 52, 239, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 3, 11, 43, 52, 239, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "55534865-29af-4f77-9f08-efae56c5be2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "eb7d787a-9c33-4e6a-b4b1-5f4ef9b12a72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "5a83ab82-01a9-4f6c-b2ba-e65a643d558f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "883acb1e-a27c-4399-a537-263d2134676f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "665a45f3-4b96-46a2-927a-e668b9ccc2b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d602681-8873-474d-805d-2d3f5ac01784", "AQAAAAEAACcQAAAAEJ6uJ5bSi1eUebfoU5D5u4lDslDdvI+TqqtHRkAhYyJjv8WdfWYYJm8NID0rZ+y/7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c7d928a-6eb1-4986-8208-23b54f266c2c", "AQAAAAEAACcQAAAAECNQ7Jt76tZjVgT+wpZiLpL7VhPfnjPqbUJlwqymWRZXeQxXB7AfT2rSuE80W3pa+A==" });
        }
    }
}
