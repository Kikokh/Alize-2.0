using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class RemoveCryptoKeyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("864d7440-d42e-42e0-9e29-bac987a31028"),
                column: "EncriptedPassword",
                value: "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("864d7440-d42e-42e0-9e29-bac987a31028"),
                column: "EncriptedPassword",
                value: "CfDJ8Ev1k98Oc-dJts7S6Q8ReyFv4Fl-MgnGTR_5FPbmr5EbDDueJq6i94N8UWVtaLrafR3iGRpaeOQElfGtScjFyTQ8167WRfnjij-J8i6oJezkgiVAF8-ozQzSlnqOTPPRtArl_traKRJNE7JdXwHoNBc_ldSgiob-LV7ZSttrOKSl2cgvO20hL617N1ex2vX9zx0jbDm1UfYhtEZvJWTlnXU");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 23, 14, 16, 19, 415, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "e718ed29-89b1-47aa-8276-e4420910e939");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "4494bcf0-f807-4328-b724-093a5a4e28fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "6b0f81b1-3840-4a86-9104-862843dae968");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "87b0a84f-85a1-4a4b-a124-4a708f5f38f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "b06fac64-868f-4834-b98a-fa75a3f6630b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a93f2b2-3be5-45d7-a816-0d160b798a7a", "AQAAAAEAACcQAAAAEEzgPhSppc30afnODjH6m22w2aqtOyw2cjZCTLcJ2+9m76z0Hc0E1piU2UWThrn0qw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47499224-1ee6-4aeb-b63f-a2e8d847fbba", "AQAAAAEAACcQAAAAEMEonCLQ5+3J88EDsj9v7QQsfX/1ORVvqEAjuOHOP6br1HWls9O/G5kPGufVqBeGAg==" });
        }
    }
}
