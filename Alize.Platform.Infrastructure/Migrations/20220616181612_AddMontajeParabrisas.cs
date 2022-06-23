using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class AddMontajeParabrisas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b87"), new Guid("e8528a43-2a9d-44dd-b1c9-e37777ad0644"), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secuenciación parabrisas ford", true, "Montaje parabrisas" });

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

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncriptedPassword", "Username" },
                values: new object[] { new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca6"), new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b87"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca6"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b87"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELW/bMvnrCdI/6BfbhN+mH2P29Ux76M//PvtHimjPwo5ItYYklrMel+xWRz3etFaXA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELdtEi/cuHGtublx1maS8chKvM0dL73VD1tTbepvZoVXdWMq1TcehPqVRkMFPkf+3w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEF2FFS2lwMe3p/6s7A+cqCbui5Nt81ZVjYUjr0WbVfGRr2DSDRjrFfdiSGnUZm9kSg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGdCBA3koHfHYux403xMjGFUZ3neXj2b77TjZA9y7yDfBeZ7CuM60wvnLGNTd5XcLQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPoF5SEZf2/lCCRxcOZgFdrOvDVfKcPJKsooByTMYyDaRN7UYRmeq+XVKy1NP8oObA==");
        }
    }
}
