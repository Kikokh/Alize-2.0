using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class addTrazabilidadRacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("0f5bc658-7223-4c5a-b272-31e878f181d6"), new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro trazabilidad de racks secuencia", true, "Trazabilidad Racks" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEA/KdrAVwf+EiWLU+f4wFqZ7YX/iYp+znDG7B4Ny6fp3wdAQO/dB3Etcci9ypBKfEQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJX53Tpky17jJZ00ndSA0wgQSzxVJ7icolmGwzsZ7OnioGPw4LRXqlePIQhhKSp72g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENqkATMDtXSuhSFSMXBOJQn0/Puv1U22G94dFwlCINm51x6oZ3PBFgaQHBHcIF4q3g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAED2+IfT+J2vRkpGRWnMRH5k3ZZL3XDjL3X1wY4hBDVOpAjrjQja9Yt0DVPWFUiWA1w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHCHsUwpSLatI7IIOLF/+dra+xFc1/xAlx3XMuHS1Z2KVbEtywLL5JQTFVkz+BtkBA==");

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fde"), new Guid("0f5bc658-7223-4c5a-b272-31e878f181d6"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "1f893f83132b8b5946e4cb37d205fb0ba6314380020139b23e48e6c6f06037be", "6155a34df2452452c3c75a1a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fde"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("0f5bc658-7223-4c5a-b272-31e878f181d6"));

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
