using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class AddCryptoKeyValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("864d7440-d42e-42e0-9e29-bac987a31028"),
                column: "EncriptedPassword",
                value: "CfDJ8OVxN162SLRJjkJckx9xddOS9DkX9iWy4aWGRwkyP5gC7oh_kce92lm5dY4SXuL6bwrBmizWw7Gui12vSEsMV76wf77IQ7NAG9oTbocm5dMrjLBoh9LrIy2Jxvl2S77Hmg2cJXSzvoL_FzWiSItwdiZBlIvjlqaVNL6BFLOrvTiIc1vd-k9puf8eHr9oQ-BzwiN8E-m6J2sJFh57HfYRAYo");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0a3"),
                column: "CreationDate",
                value: new DateTime(2022, 5, 23, 13, 57, 26, 778, DateTimeKind.Local).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "daf48b85-ae4a-4f66-b2ad-d79fe969c544");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde250-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "c97a967b-f4d8-4c90-8457-1471485fffad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33dde740-ddde-42db-a4b9-5a2355082391"),
                column: "ConcurrencyStamp",
                value: "33b82bbc-6bd5-4a16-b070-a350869a2289");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "4be77568-7429-4807-8d79-01e37dac136f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caddad05-120f-48a8-b659-ff4528e5df97"),
                column: "ConcurrencyStamp",
                value: "a3d0b4ed-97f3-4676-acb0-695b40d47c6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a41fa5f8-ed1e-448d-8d38-4d4f4d967b72", "AQAAAAEAACcQAAAAELYWEIScK6dko8D61X47gRX4S+Ngn8pJAcMWSneL5D3FWBxIgmtszo1vi8wKK67SEg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ba66596-1255-4643-a2fd-96b7ca2a5814", "AQAAAAEAACcQAAAAEDR6K7AQQRX2whYefa2gfqXlELrcGNhFxnWBeQ9/BxTNAkUUxTxP+G407bGUlC/ZXQ==" });
        }
    }
}
