using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingCapstone.Migrations
{
    public partial class scaffoldedmonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389da72d-f645-4b4c-bebd-98e2581c0b1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af74b84b-2970-44fe-b427-289c8da03e51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1a3606b-6020-416d-a3ae-ef5c779152ad", "6e295d67-d355-4e45-9f73-868f3e0470fa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "461a1256-aa8f-4c45-9711-a21eafd626a5", "1f44fdd7-faa4-443f-897a-1efc8ba5346f", "Explorer", "EXPLORER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "461a1256-aa8f-4c45-9711-a21eafd626a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a3606b-6020-416d-a3ae-ef5c779152ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af74b84b-2970-44fe-b427-289c8da03e51", "6a4ba9bd-314e-4829-9f38-bda7d4641e9b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "389da72d-f645-4b4c-bebd-98e2581c0b1e", "eec3a8de-4347-47c3-a926-5a4557af24c3", "Explorer", "EXPLORER" });
        }
    }
}
