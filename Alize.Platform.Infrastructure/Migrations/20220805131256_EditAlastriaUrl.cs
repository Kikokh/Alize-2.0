using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alize.Platform.Infrastructure.Migrations
{
    public partial class EditAlastriaUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("004286d4-a835-45c7-8f36-1f9359d7d955"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECQghetDal7L1lesb7HWyIz6oNFMaN7YkeGUjvgG5vwDIxjUkiu9xfTwKRNRggaPTw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c822965-eb67-4092-9cf7-cf62806d5395"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKJMkCvWteMdZwuljm2w+fLL56Wnt/5r1EUzbtvpES52O7mmEpo5qVm+UZ2Mk7xHZA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("840411eb-2f77-4444-8f29-76c094834b56"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK9epr800lNuYaDEr1mgCHr/y5GV8G6ODzr7G9oVSxlapMINVEg4gom98WuZEPodkg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ada776-f3e1-42db-aa39-382f91b74cd4"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMpTQ7kQtGdhp3a22btuL/eKxKQZyiJHpbK6AEeVR1FbTXHuDe0JARN/nUo3RJIdWw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6091148-6b17-4e26-9dc7-97d1b34fb025"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFEtkG79VTED42UPSQR9xx57DjOCDgdx7+X54UiiGAtPvkfnDcQVjNwe83Wl8atKJQ==");

            migrationBuilder.UpdateData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"),
                column: "ApiUrl",
                value: "https://20.216.158.33/api/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Blockchains",
                keyColumn: "Id",
                keyValue: new Guid("ba959be5-0b32-443e-a2f9-98a0f3c8a7e1"),
                column: "ApiUrl",
                value: "https://20.73.2.29:443/api/");
        }
    }
}
