using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class LinkAppCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials");

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("558ae1ca-63d2-4dd2-b18a-e80136d9315e"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca6"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("864d7440-d42e-42e0-9e29-bac987a31028"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fde"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOuX2M6kjEZVzkTYcA74JxykyQiFqblH9s+v/Bytu/ZZL40TTkE6Q1m6FTeqJ26q9Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG3sHmpXwgWzXf9xprgBrDQ7Ih+gHL182vBdzpNw2Ex6eQzcALSrrzvPXACeJmt/AQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG5Xdz2aFq4zxdtdsTPJ6nyG42ENcvx2ZVfIubBbX6QLlIlVNs5/cjexd+tFovFdUQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMSwWG0rNH9o9W63NxXB4piwHoLYyS/HKBS7hgVjw738CnZtaBvgh5AJm+/fvORmxg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOylzuBbtST/o2iRxN2SP9/JDfydF7BvXR82n4HGND+bNE2SygsoGP2ZJLAMw2uzWQ==");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials",
                column: "ApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials");

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("558ae1ca-63d2-4dd2-b18a-e80136d9315e"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca6"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("864d7440-d42e-42e0-9e29-bac987a31028"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fde"));

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncryptedPassword", "Username" },
                values: new object[,]
                {
                    { new Guid("558ae1ca-63d2-4dd2-b18a-e80136d9315e"), new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" },
                    { new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca6"), new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b87"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" },
                    { new Guid("864d7440-d42e-42e0-9e29-bac987a31028"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436", "60ffbe3ef24524680871dc75" },
                    { new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fde"), new Guid("0f5bc658-7223-4c5a-b272-31e878f181d6"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "1f893f83132b8b5946e4cb37d205fb0ba6314380020139b23e48e6c6f06037be", "6155a34df2452452c3c75a1a" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIFZ9a5kbn4L7ybmENUFo9fJyPXeGTp96/b7dpXjzVQmga9icrkP7xkhEDPW/ZZpcA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK+GLa4+4as+7q0U4hJwCWxFdeDwC+9RGh4awQkbIV/6MwcVM1wc8uSlPDfl93wYIw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGf8Z5i67ffC8bfrC2AVHYxalw05YrtynpDbwa5N+GF8c4pp004aJ20JclqG2sXA9Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEI7ziSKa/upRyHUE8cTCEfWG27kH99I1jwRaiqca6JBjCACKmWa7WtDUyBi0Iqzg8g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEP2kCfgIIh9LastRBv5vPO1V+1/sYiJLkF/ZbWgggWeYVvcyKQfwJ0Lz6FYk7gvqTQ==");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationCredentials_ApplicationId",
                table: "ApplicationCredentials",
                column: "ApplicationId");
        }
    }
}
