using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class SeedMoreApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0f5bc658-7223-4c5a-b272-31e878f181d5"), new Guid("f20a5162-ebe9-48d0-92ae-d3cca917fc43"), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Registro trazabilidad de racks secuencia", true, "Trazabilidad Racks" },
                    { new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b86"), new Guid("2f3e3858-4a59-4f0a-a54f-1830e47a9dfe"), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secuenciación parabrisas ford", true, "Montaje parabrisas" },
                    { new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0b3"), new Guid("554bc4f7-46a9-4a87-a52e-6ca79e24986c"), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huella de carbono en proceso de montaje parabrisas", true, "Huella carbono" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG1p7j4RzamSCAaKJHIt0sm7TBfJVdrCafJCS+rV14B69kxhN1/Ba/pneM7XJtFdRw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEESYapLJamJD+W7Mnci19PD+Vlboo/YLI0CDUYyibWTmwIaulSwdVSWcwWkqwnP6NA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEN6ugKBQHlpPpvAkBzTlNhxcPVCEiGEt2fbnEA85rZ03Za1d8UWV63Jz6xaF6PmW4g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEDxxBCGPX6ET+hkEkYINfkXs64PXhmrtrqesV/bUUaqXfDrpDbRLJCzC0gZLsMz0Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOplq3M2cxEemfpjSIO2eu2hP0pOCi4l+cmhVCdYRxAdQ4gwIXHmv/Y8FqZRubK9EQ==");

            migrationBuilder.InsertData(
                table: "ApplicationCredentials",
                columns: new[] { "Id", "ApplicationId", "BlockchainId", "EncryptedPassword", "Username" },
                values: new object[,]
                {
                    { new Guid("26053ad3-d72b-46c3-b4a0-691ed4d13ca5"), new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b86"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "iC4glPRztsdBn/u1Ll6txQ==", "admin_kh_trazabilidad_ws" },
                    { new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fae"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0b3"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" },
                    { new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fbe"), new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0b3"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "iC4glPRztsdBn/u1Ll6txQ==", "admin_kh_trazabilidad_ws" },
                    { new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fd4"), new Guid("0f5bc658-7223-4c5a-b272-31e878f181d5"), new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"), "TLC+5AObeVZds5qQktvujQ==", "admin_kh_racks" },
                    { new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca5"), new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b86"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "7b12c0e83055b12924509de76d14c2ee5aca90367f7938973e49e650e3b9579d", "61e844e4f245240292cf8641" },
                    { new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fd5"), new Guid("0f5bc658-7223-4c5a-b272-31e878f181d5"), new Guid("56eab269-09ce-4332-b395-7dfcb17b073d"), "1f893f83132b8b5946e4cb37d205fb0ba6314380020139b23e48e6c6f06037be", "6155a34df2452452c3c75a1a" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26053ad3-d72b-46c3-b4a0-691ed4d13ca5"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fae"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fbe"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("26bbad1a-0653-44a0-8ca7-4b8458f80fd4"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("76053ad3-d72b-46c3-b4a0-691ed4d13ca5"));

            migrationBuilder.DeleteData(
                table: "ApplicationCredentials",
                keyColumn: "Id",
                keyValue: new Guid("86bbad1a-0653-44a0-8ca7-4b8458f80fd5"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("0f5bc658-7223-4c5a-b272-31e878f181d5"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("892494ab-f4f5-4b76-a2f8-aa1e042e6b86"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("8a0573a2-4573-45a1-96eb-4b0233c1e0b3"));

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
        }
    }
}
