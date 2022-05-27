using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class ReanameGroupsToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 26, 16, 53, 50, 355, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "ec8ed315-4868-4405-9157-bbfb36169302");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "7668ce9d-5e77-4b83-ace5-c0af21802e75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "1df8f138-ab0d-4b9c-b54c-3e9b7e71e1e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "6f7d61a9-11d2-4197-bb98-e79b91eddce4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "0a92a9fd-c066-4c85-bc7d-ff30819573f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3d02e5b-2ebd-4227-b42a-e6fe781acd0b", "AQAAAAEAACcQAAAAEJF8ghRDDbtDJM8laMzDxijyePEMiQa4fiLc5ZBuBOg6Z1G6xWtiFURjTIXpwZJMsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7c81813-845a-4cf5-8648-b9db2ffe38d4", "AQAAAAEAACcQAAAAECbf/T2VBqytaU3jUHUvbq6nCPnvkpjDpFpb0ilF1T3yTlVnwUNITYzJhqKVI1usrQ==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "Name",
                value: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 23, 14, 36, 11, 664, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "24cc20e6-6145-4b81-9777-1a300e6a2a76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "3298544e-e8bb-4858-88ab-e320b5dcd6c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "2bbdf498-85e5-44d9-b7db-d8df6b294a99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "608334eb-4228-4e39-b21b-9c6fa09461af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "8cc537f3-a391-4f0a-82c5-2da8024bd450");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3858c25-14d8-43e7-9b82-2e04732be79b", "AQAAAAEAACcQAAAAEBbpkJKjDzob8qUurjg+tZqJdS2d+ZfXCMoV8hEgVMOTuZ5JvhQKKz4vBj1pjIun9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "afff9dc3-25d3-4779-a2d8-0c6834eb793b", "AQAAAAEAACcQAAAAEC/uvVeEjOj4yd8Gp9t5TDg5+fOClizXUO8Z4faBSDa/2aZdO75o1F6uzI0p6SGxvA==" });

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("9141e022-2833-4a18-a7b9-7f20a6b39768"),
                column: "Name",
                value: "Grupos");
        }
    }
}
