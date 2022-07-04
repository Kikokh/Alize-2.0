using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class AlastriaCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGkbOUIl1t3C7lNswTy/lndX4Vkjc81iPJJDo18LZkC+sdFdx7/fSHWtI/C4wEcqBA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHuT69hSSeyXZGOdBRF3mpAVv/8BAIjjKK53gd7qJ8AsWaYaucx8hAlW3UR1NO/VQg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOlkkniiCAq35pJmOwLPHUxAiJ2ca2PYPsRYMjnCZPR825FHdMPuI5TUBSOmjEV6Dg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEO44310weAuVYg9xIHsFPvWN4cQ1xhSL6AqR9VTFiGXqS5Q70/EcF6XNyGTp5E8QPg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIsVGewJSv8OMt5nc5dMNkfmMw/nCGdiFIPyZhyRPkPinEJQ0dLv7DeQQaaJOM5M4w==");

            migrationBuilder.InsertData(
                table: "Blockchains",
                columns: new[] { "Id", "ApiUrl", "Name" },
                values: new object[] { new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "https://20.73.2.29:443/api/", "Alastria" });

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("0af7dff5-9b0f-448a-994a-ef8b54a68708"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "password1234", "admin_calidad_mapex_test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("0af7dff5-9b0f-448a-994a-ef8b54a68708"));

            migrationBuilder.DeleteData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKHsURHeptyJhZdFiSy8jCyG+cTp5JtrypL8+OLwMW/sI4rwNI6tQps1BC15nNklLQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAqL1AoP/nXopJm43lLqnBIIiTVLUvtUhONQ00xwUQV77aofCrCU+9X+djlCSUhpMg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBn1uKhDIxZe9VmCrFYeA9lli4wpI4QQXVc5oM0g8sah3C1j+/4MIeyGXasc5dXRAg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPXzIURhVcsHM9XpNq70DpSzoW2hb9XISuX+JYr+WkanQ6o+u11BNtpyEVNRCvBJAg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHlL5BW2VGxasNdLE9v5a5zTKzx8OAMNWipEidn0BdelkXNOA4jo1AEWKURECNDNkg==");
        }
    }
}
