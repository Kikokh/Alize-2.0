using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class UpdateBlockchainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncriptedPassword",
                table: "ApplicationCredentials",
                newName: "EncryptedPassword");

            migrationBuilder.AddColumn<string>(
                name: "RootEncryptedPassword",
                table: "Blockchains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootUserName",
                table: "Blockchains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEXXvRYbqB2kOUx3iS9nzJ68fI/Z5a5w2lhZbil5Ek92p0oHr6u6f0sp63zi+kdY5A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPE8BjU5ILheN0OVIlw8fHzgVLlLfxCX0H54Thv2TXqSg8/ivd3zE36DtRIVd/tLmQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEYbh8Rn8+O71VWf94wf+lv3hgBFvQ0voLjAhPBdwU55BUC0VFo+UAZudW2yTnCguA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECs7P7aG5bOOXXKP3NclSAJebaOX9zQ4wyXqvf335XkKau/p0y0c6NFGDFDlp63/pg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEO/qu0TRwFj5ECNq5iz+YmjDtENXHQwyQZ2mViJ1O4C48vWCWsrrDw1VAbQHDBe7vQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RootEncryptedPassword",
                table: "Blockchains");

            migrationBuilder.DropColumn(
                name: "RootUserName",
                table: "Blockchains");

            migrationBuilder.RenameColumn(
                name: "EncryptedPassword",
                table: "ApplicationCredentials",
                newName: "EncriptedPassword");

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
        }
    }
}
