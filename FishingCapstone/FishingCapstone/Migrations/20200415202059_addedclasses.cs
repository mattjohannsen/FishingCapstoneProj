using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingCapstone.Migrations
{
    public partial class addedclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54e96287-4329-4ed5-a712-60af834eb467");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f85e49c2-a7a1-4d79-a8a1-11527eb6b730");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "633a0cec-322b-43fe-a459-687b4cfd78e2", "7da31edf-8e89-440b-9794-ab2b9f6b5609", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c3621df-5484-4117-baaa-0a1101b5ff7a", "2eed6059-4743-46a1-ab6e-3782efb2d4db", "Explorer", "EXPLORER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3621df-5484-4117-baaa-0a1101b5ff7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "633a0cec-322b-43fe-a459-687b4cfd78e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54e96287-4329-4ed5-a712-60af834eb467", "31ba42e9-da51-442a-b584-c99ee72faef3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f85e49c2-a7a1-4d79-a8a1-11527eb6b730", "d94946ad-4920-48cc-ad14-2b835203d0de", "Explorer", "EXPLORER" });
        }
    }
}
