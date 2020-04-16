using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingCapstone.Migrations
{
    public partial class availableSpeices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b31bd19-1200-4341-9764-d0d8f6568f3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5106dc46-38bc-4e7e-b97e-e8a22077e562");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34127eca-ee34-4460-a65d-4199f0b9b7fb", "26de82d1-d110-43fd-8cd5-e1698c7d4583", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e50a0016-2707-4410-863e-3b6cc866724b", "432df1ce-a607-448b-bab0-f1318719adc6", "Explorer", "EXPLORER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34127eca-ee34-4460-a65d-4199f0b9b7fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e50a0016-2707-4410-863e-3b6cc866724b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b31bd19-1200-4341-9764-d0d8f6568f3d", "0994620d-add1-43f4-a313-df7362c28d25", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5106dc46-38bc-4e7e-b97e-e8a22077e562", "bc94e71e-1d7b-413c-9801-99f8fa28f1d4", "Explorer", "EXPLORER" });
        }
    }
}
