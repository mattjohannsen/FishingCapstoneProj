using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingCapstone.Migrations
{
    public partial class AddPhotosToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80072ecd-5a58-4d48-9f7f-a69ee4aa6f7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c154fc73-1eae-487d-97f0-4f7d62780256");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoFile = table.Column<string>(nullable: true),
                    PhotoTripId = table.Column<int>(nullable: false),
                    PhotoCaption = table.Column<string>(nullable: true),
                    PhotoLat = table.Column<string>(nullable: true),
                    PhotoLong = table.Column<string>(nullable: true),
                    PhotoDate = table.Column<int>(nullable: false),
                    PhotoData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotosId);
                    table.ForeignKey(
                        name: "FK_Photos_Trip_PhotoTripId",
                        column: x => x.PhotoTripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc6df44-d6bc-40db-97b3-970378bd6c1c", "ed3faa0f-6638-4792-8511-2a0abedf8681", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddcabe85-5c0b-4a70-a540-7952216d3b5b", "dd42c51a-2172-4149-8098-d92b55b35a5a", "Explorer", "EXPLORER" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoTripId",
                table: "Photos",
                column: "PhotoTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc6df44-d6bc-40db-97b3-970378bd6c1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddcabe85-5c0b-4a70-a540-7952216d3b5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c154fc73-1eae-487d-97f0-4f7d62780256", "a6a41f96-d99b-4bef-b89d-0a80c6c85c79", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80072ecd-5a58-4d48-9f7f-a69ee4aa6f7e", "441b1514-4765-4be8-9278-8ea47e630a5d", "Explorer", "EXPLORER" });
        }
    }
}
