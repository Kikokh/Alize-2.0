using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class ApplicationSeedHuellaCarbono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 3, 11, 43, 52, 239, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"), new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), new DateTime(2022, 6, 3, 11, 43, 52, 239, DateTimeKind.Local).AddTicks(7712), "Huella de carbono en proceso de montaje parabrisas", true, "Huella de carbono" });

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

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("558ae1ca-63d2-4dd2-b18a-e80136d9315e"), new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("558ae1ca-63d2-4dd2-b18a-e80136d9315e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 31, 11, 3, 8, 637, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "77df4cc3-df44-43ea-b79b-9fda5b17151c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "f619be29-6b0e-460c-80ff-fea3a1b80dcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "baedee95-6e73-4d32-bcf2-895e49e45d7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "53566433-3892-4584-addb-910dd11c5d79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "fe03710c-df40-4548-a2d1-7ea0948b6833");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc453d2e-f1f5-41d9-80df-ac8f97385a80", "AQAAAAEAACcQAAAAEO2sH03H20icuzEnC8ech0fVL59auf4PeIfTZj41dFlCe8yhMDsBEkX2RbucX6muQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0e914495-0a69-47f3-9936-0db40398f91a", "AQAAAAEAACcQAAAAEJVrjHOfyPbBBIA6EqzgkvjgRz5pfFJLvn4w+cykSKQnA61qpn5mRR1wbiw03SYRcA==" });
        }
    }
}
