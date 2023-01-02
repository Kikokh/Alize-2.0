using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class RemoveCredentialsFromBlockchainClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "RootEncryptedPassword",
                table: "Blockchains");

            migrationBuilder.DropColumn(
                name: "RootUserName",
                table: "Blockchains");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPcVojOl8cGwSrzVjyuxp0NeqjlXUxLIb7DddqiKEkZUikubILJPIdL6PLVmkJpNHA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK5mMEWbNZIperOiMh/3j5LR1BIbyyicTzjQeQXNS0O179NgwldbLMMQ/EmtZnAReQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFcCGraf8c6ZJcemvK4XXOwKPj1QhRzvLyKaHOCbznYnO0W304ac78gvC8jxwGptKg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDfVnkI1o3QjyXcASZGgF6BDQ8c1SP9SB+ldMuOrHPmj96kO3QqVJzIykYDwdjLpsQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBt6e0mHJI6TduDmqxOuRxiNSH+OFSu92WoyQP2Yk+H239TTDfFPf7UDxF3y9M/M0A==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "AQAAAAEAACcQAAAAELztRaGT/n/MUKBpEo05xIoklka/yhOToIFRSJVo74VhgWZeQthZ21mw9BGMwDnu8w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKKQNH0xM+olgeu3PvBKA+7KNJJqvJjvW8IKre+zZ7jNiXCj1KkXsHzNl5opA5UpUQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMlh8pr35iRE9QZqexdPQxcMZ+eMgyzSEEHKxaOenKQqDMo87Yn4V1yGuRNcxJg9ig==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEI5ufTSZFaRssC1ryFB8Cjb6DI9cUDOMROE7ani8RAGhOk9lOo0FDfOuGekgNHXMPg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJvKobaGd0IS3nncuI3BlBXrQp0jdl3Ift6/VYPQxmkNgUgiEhhsnY4qkfTV1maZtQ==");

            migrationBuilder.UpdateData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"),
                columns: new[] { "RootEncryptedPassword", "RootUserName" },
                values: new object[] { "hfnqSR5BhccxGBclgTzR2Q==", "root" });
        }
    }
}
