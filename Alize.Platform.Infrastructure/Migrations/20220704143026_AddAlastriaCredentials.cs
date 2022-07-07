using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class AddAlastriaCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("0af7dff5-9b0f-448a-994a-ef8b54a68708"),
                columns: new[] { "EncryptedPassword", "Username" },
                values: new object[] { "bSdT/34j9DB3VObnxn6wuQ==", "admin_kh_calidad_mapex" });

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncryptedPassword", "Username" },
                values: new object[,]
                {
                    { new Guid("258ae1ca-63d2-4dd2-b18a-e80136d9315e"), new Guid("de017cbb-fc9f-45e0-9f2c-c777a257fee7"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "iC4glPRztsdBn/u1Ll6txQ==", "admin_kh_trazabilidad_ws" },
                    { new Guid("26053ad3-d72b-46c3-b4a0-691ed4d13ca6"), new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b87"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "iC4glPRztsdBn/u1Ll6txQ==", "admin_kh_trazabilidad_ws" },
                    { new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fde"), new Guid("0f5bc658-7223-4c5a-b272-31e878f181d6"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "TLC+5AObeVZds5qQktvujQ==", "admin_kh_racks" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJxm17ThcoDrYApVxo8Oo/MUJcZXviAJp9uhHROcvd6OS+ScDUcnOovCgwnalyPbHQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEO6wBYLYVNjXG7i1u+I3FNkHXHrlNuM0JO7ZV9FhC3fOvuBi3J1rp0OXTd9UPLftQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK6y+hsknueMZTNJA826t9WuL7yUPneGOLmOfxHwcI6+urARuVyqiIHnd4qW96U6zw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEHjXjYmxiBggBy9rtDxHddiIXZcOpnkViCMob4aJl/hbNs9xNtQN843gDoaTQbx/A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECRGj7MgUukkHCQocmabE8PRFX/lTy8FLCHQXYR3XZ4P82B+Ngrmel3AJg+GMbIOCg==");

            migrationBuilder.UpdateData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"),
                columns: new[] { "RootEncryptedPassword", "RootUserName" },
                values: new object[] { "hfnqSR5BhccxGBclgTzR2Q==", "root" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("258ae1ca-63d2-4dd2-b18a-e80136d9315e"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26053ad3-d72b-46c3-b4a0-691ed4d13ca6"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fde"));

            migrationBuilder.UpdateData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("0af7dff5-9b0f-448a-994a-ef8b54a68708"),
                columns: new[] { "EncryptedPassword", "Username" },
                values: new object[] { "password1234", "admin_calidad_mapex_test" });

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

            migrationBuilder.UpdateData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"),
                columns: new[] { "RootEncryptedPassword", "RootUserName" },
                values: new object[] { null, null });
        }
    }
}
