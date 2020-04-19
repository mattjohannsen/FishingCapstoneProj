using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishingCapstone.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationName = table.Column<string>(nullable: true),
                    DestinationLat = table.Column<string>(nullable: true),
                    DestinationLong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    MonthId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingName = table.Column<string>(nullable: true),
                    RatingNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    AdminFirst = table.Column<string>(nullable: true),
                    AdminLast = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Explorer",
                columns: table => new
                {
                    ExplorerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explorer", x => x.ExplorerId);
                    table.ForeignKey(
                        name: "FK_Explorer_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestSpeciesMonth",
                columns: table => new
                {
                    DestSpeciesMonthId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DSMDestinationId = table.Column<int>(nullable: false),
                    DSMSpeciesId = table.Column<int>(nullable: false),
                    DSMMonthId = table.Column<int>(nullable: false),
                    DSMRatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestSpeciesMonth", x => x.DestSpeciesMonthId);
                    table.ForeignKey(
                        name: "FK_DestSpeciesMonth_Destination_DSMDestinationId",
                        column: x => x.DSMDestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestSpeciesMonth_Month_DSMMonthId",
                        column: x => x.DSMMonthId,
                        principalTable: "Month",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestSpeciesMonth_Rating_DSMRatingId",
                        column: x => x.DSMRatingId,
                        principalTable: "Rating",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestSpeciesMonth_Species_DSMSpeciesId",
                        column: x => x.DSMSpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "249f49cb-621e-4d48-9efe-bfbe2e52fe3d", "6cfdb50b-2193-4055-af5f-8ccbfeac6075", "Explorer", "EXPLORER" },
                    { "eb00fa9e-5478-4166-80c9-96a1e04e0ca6", "3e095528-717c-4dc5-b7d0-815061d470f3", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "DestinationLat", "DestinationLong", "DestinationName" },
                values: new object[,]
                {
                    { 4, "43.412800", "-88.189249", "West Bend, WI" },
                    { 1, "22.8822", "-109.91203", "Cabo San Lucas, MX" },
                    { 3, "24.167785", "-110.310101", "La Paz, MX" },
                    { 2, "20.468355", "-86.978845", "Cozumel, MX" }
                });

            migrationBuilder.InsertData(
                table: "Month",
                columns: new[] { "MonthId", "MonthName" },
                values: new object[,]
                {
                    { 1, "January" },
                    { 2, "February" },
                    { 3, "March" },
                    { 4, "April" },
                    { 5, "May" },
                    { 6, "June" },
                    { 7, "July" },
                    { 8, "August" },
                    { 9, "September" },
                    { 10, "October" },
                    { 11, "November" },
                    { 12, "December" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "RatingName", "RatingNumber" },
                values: new object[,]
                {
                    { 4, "Best", 4 },
                    { 2, "Fair", 2 },
                    { 1, "Poor", 1 },
                    { 3, "Good", 3 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "SpeciesName" },
                values: new object[,]
                {
                    { 23, "Yellowtail" },
                    { 22, "Wahoo" },
                    { 15, "Red Snapper" },
                    { 21, "Tuna" },
                    { 20, "Snook" },
                    { 19, "Skipjack" },
                    { 18, "Shark" },
                    { 17, "Sailfish" },
                    { 16, "Roosterfish" },
                    { 14, "Pargo - Dogtooth Snapper" },
                    { 5, "Grouper" },
                    { 12, "Marlin - Striped" },
                    { 11, "Marlin - Blue" },
                    { 10, "Marlin -Black" },
                    { 9, "Mahi Mahi - Dorado" },
                    { 8, "Mackerel - Sierra" },
                    { 7, "Kingfish" },
                    { 6, "Jack Crevalle" },
                    { 4, "Cabrilla" },
                    { 2, "Barracuda" },
                    { 1, "Amberjack" },
                    { 13, "Marlin - White" },
                    { 3, "Bonito" }
                });

            migrationBuilder.InsertData(
                table: "DestSpeciesMonth",
                columns: new[] { "DestSpeciesMonthId", "DSMDestinationId", "DSMMonthId", "DSMRatingId", "DSMSpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 1 },
                    { 13, 1, 1, 3, 16 },
                    { 32, 1, 2, 3, 16 },
                    { 51, 1, 3, 3, 16 },
                    { 70, 1, 4, 3, 16 },
                    { 89, 1, 5, 4, 16 },
                    { 108, 1, 6, 4, 16 },
                    { 392, 2, 12, 4, 15 },
                    { 127, 1, 7, 4, 16 },
                    { 165, 1, 9, 2, 16 },
                    { 184, 1, 10, 2, 16 },
                    { 203, 1, 11, 3, 16 },
                    { 222, 1, 12, 3, 16 },
                    { 407, 3, 1, 1, 16 },
                    { 423, 3, 2, 1, 16 },
                    { 146, 1, 8, 4, 16 },
                    { 378, 2, 11, 4, 15 },
                    { 364, 2, 10, 4, 15 },
                    { 350, 2, 9, 3, 15 },
                    { 107, 1, 6, 4, 15 },
                    { 126, 1, 7, 4, 15 },
                    { 145, 1, 8, 4, 15 },
                    { 164, 1, 9, 4, 15 },
                    { 183, 1, 10, 3, 15 },
                    { 202, 1, 11, 2, 15 },
                    { 221, 1, 12, 3, 15 },
                    { 238, 2, 1, 3, 15 },
                    { 252, 2, 2, 1, 15 },
                    { 266, 2, 3, 1, 15 },
                    { 280, 2, 4, 1, 15 },
                    { 294, 2, 5, 1, 15 },
                    { 308, 2, 6, 1, 15 },
                    { 322, 2, 7, 1, 15 },
                    { 336, 2, 8, 1, 15 },
                    { 439, 3, 3, 2, 16 },
                    { 455, 3, 4, 3, 16 },
                    { 471, 3, 5, 4, 16 },
                    { 487, 3, 6, 4, 16 },
                    { 253, 2, 2, 3, 17 },
                    { 267, 2, 3, 4, 17 },
                    { 281, 2, 4, 4, 17 },
                    { 295, 2, 5, 4, 17 },
                    { 309, 2, 6, 4, 17 },
                    { 323, 2, 7, 4, 17 },
                    { 337, 2, 8, 3, 17 },
                    { 351, 2, 9, 2, 17 },
                    { 365, 2, 10, 1, 17 },
                    { 379, 2, 11, 1, 17 },
                    { 393, 2, 12, 1, 17 },
                    { 408, 3, 1, 1, 17 },
                    { 424, 3, 2, 1, 17 },
                    { 440, 3, 3, 1, 17 },
                    { 456, 3, 4, 1, 17 },
                    { 239, 2, 1, 2, 17 },
                    { 88, 1, 5, 4, 15 },
                    { 223, 1, 12, 3, 17 },
                    { 185, 1, 10, 4, 17 },
                    { 503, 3, 7, 4, 16 },
                    { 519, 3, 8, 2, 16 },
                    { 535, 3, 9, 2, 16 },
                    { 551, 3, 10, 2, 16 },
                    { 567, 3, 11, 1, 16 },
                    { 583, 3, 12, 1, 16 },
                    { 14, 1, 1, 2, 17 },
                    { 33, 1, 2, 1, 17 },
                    { 52, 1, 3, 1, 17 },
                    { 71, 1, 4, 1, 17 },
                    { 90, 1, 5, 2, 17 },
                    { 109, 1, 6, 2, 17 },
                    { 128, 1, 7, 3, 17 },
                    { 147, 1, 8, 3, 17 },
                    { 166, 1, 9, 4, 17 },
                    { 204, 1, 11, 4, 17 },
                    { 472, 3, 5, 2, 17 },
                    { 69, 1, 4, 4, 15 },
                    { 31, 1, 2, 3, 15 },
                    { 181, 1, 10, 3, 12 },
                    { 200, 1, 11, 3, 12 },
                    { 219, 1, 12, 3, 12 },
                    { 405, 3, 1, 1, 12 },
                    { 421, 3, 2, 1, 12 },
                    { 437, 3, 3, 1, 12 },
                    { 162, 1, 9, 3, 12 },
                    { 453, 3, 4, 1, 12 },
                    { 485, 3, 6, 3, 12 },
                    { 501, 3, 7, 3, 12 },
                    { 517, 3, 8, 4, 12 },
                    { 533, 3, 9, 4, 12 },
                    { 549, 3, 10, 3, 12 },
                    { 565, 3, 11, 1, 12 },
                    { 469, 3, 5, 1, 12 },
                    { 143, 1, 8, 3, 12 },
                    { 124, 1, 7, 4, 12 },
                    { 105, 1, 6, 4, 12 },
                    { 591, 4, 3, 1, 11 },
                    { 592, 4, 4, 4, 11 },
                    { 593, 4, 5, 1, 11 },
                    { 594, 4, 6, 1, 11 },
                    { 595, 4, 7, 1, 11 },
                    { 596, 4, 8, 1, 11 },
                    { 597, 4, 9, 1, 11 },
                    { 598, 4, 10, 1, 11 },
                    { 599, 4, 11, 1, 11 },
                    { 600, 4, 12, 1, 11 },
                    { 10, 1, 1, 4, 12 },
                    { 29, 1, 2, 4, 12 },
                    { 48, 1, 3, 4, 12 },
                    { 67, 1, 4, 4, 12 },
                    { 86, 1, 5, 4, 12 },
                    { 581, 3, 12, 1, 12 },
                    { 237, 2, 1, 1, 13 },
                    { 251, 2, 2, 2, 13 },
                    { 265, 2, 3, 3, 13 },
                    { 201, 1, 11, 2, 14 },
                    { 220, 1, 12, 3, 14 },
                    { 406, 3, 1, 1, 14 },
                    { 422, 3, 2, 1, 14 },
                    { 438, 3, 3, 2, 14 },
                    { 454, 3, 4, 4, 14 },
                    { 470, 3, 5, 4, 14 },
                    { 486, 3, 6, 2, 14 },
                    { 502, 3, 7, 1, 14 },
                    { 518, 3, 8, 1, 14 },
                    { 534, 3, 9, 1, 14 },
                    { 550, 3, 10, 1, 14 },
                    { 566, 3, 11, 1, 14 },
                    { 582, 3, 12, 1, 14 },
                    { 12, 1, 1, 3, 15 },
                    { 182, 1, 10, 3, 14 },
                    { 50, 1, 3, 3, 15 },
                    { 163, 1, 9, 4, 14 },
                    { 125, 1, 7, 4, 14 },
                    { 279, 2, 4, 4, 13 },
                    { 293, 2, 5, 4, 13 },
                    { 307, 2, 6, 4, 13 },
                    { 321, 2, 7, 3, 13 },
                    { 335, 2, 8, 2, 13 },
                    { 349, 2, 9, 2, 13 },
                    { 363, 2, 10, 1, 13 },
                    { 377, 2, 11, 1, 13 },
                    { 391, 2, 12, 1, 13 },
                    { 11, 1, 1, 3, 14 },
                    { 30, 1, 2, 3, 14 },
                    { 49, 1, 3, 3, 14 },
                    { 68, 1, 4, 4, 14 },
                    { 87, 1, 5, 4, 14 },
                    { 106, 1, 6, 4, 14 },
                    { 144, 1, 8, 4, 14 },
                    { 590, 4, 2, 1, 11 },
                    { 488, 3, 6, 3, 17 },
                    { 520, 3, 8, 4, 17 },
                    { 132, 1, 7, 3, 22 },
                    { 151, 1, 8, 3, 22 },
                    { 170, 1, 9, 4, 22 },
                    { 189, 1, 10, 4, 22 },
                    { 208, 1, 11, 4, 22 },
                    { 227, 1, 12, 4, 22 },
                    { 113, 1, 6, 2, 22 },
                    { 242, 2, 1, 4, 22 },
                    { 270, 2, 3, 3, 22 },
                    { 284, 2, 4, 3, 22 },
                    { 298, 2, 5, 3, 22 },
                    { 312, 2, 6, 3, 22 },
                    { 326, 2, 7, 3, 22 },
                    { 340, 2, 8, 2, 22 },
                    { 256, 2, 2, 3, 22 },
                    { 94, 1, 5, 2, 22 },
                    { 75, 1, 4, 1, 22 },
                    { 56, 1, 3, 1, 22 },
                    { 395, 2, 12, 2, 21 },
                    { 410, 3, 1, 1, 21 },
                    { 426, 3, 2, 1, 21 },
                    { 442, 3, 3, 1, 21 },
                    { 458, 3, 4, 1, 21 },
                    { 474, 3, 5, 2, 21 },
                    { 490, 3, 6, 2, 21 },
                    { 506, 3, 7, 1, 21 },
                    { 522, 3, 8, 3, 21 },
                    { 538, 3, 9, 4, 21 },
                    { 554, 3, 10, 4, 21 },
                    { 570, 3, 11, 2, 21 },
                    { 586, 3, 12, 1, 21 },
                    { 18, 1, 1, 4, 22 },
                    { 37, 1, 2, 2, 22 },
                    { 354, 2, 9, 1, 22 },
                    { 368, 2, 10, 2, 22 },
                    { 382, 2, 11, 4, 22 },
                    { 396, 2, 12, 4, 22 },
                    { 152, 1, 8, 1, 23 },
                    { 171, 1, 9, 1, 23 },
                    { 190, 1, 10, 1, 23 },
                    { 209, 1, 11, 1, 23 },
                    { 228, 1, 12, 1, 23 },
                    { 412, 3, 1, 2, 23 },
                    { 428, 3, 2, 2, 23 },
                    { 444, 3, 3, 2, 23 },
                    { 460, 3, 4, 2, 23 },
                    { 476, 3, 5, 2, 23 },
                    { 492, 3, 6, 1, 23 },
                    { 508, 3, 7, 1, 23 },
                    { 524, 3, 8, 1, 23 },
                    { 540, 3, 9, 1, 23 },
                    { 556, 3, 10, 1, 23 },
                    { 133, 1, 7, 2, 23 },
                    { 381, 2, 11, 2, 21 },
                    { 114, 1, 6, 3, 23 },
                    { 76, 1, 4, 4, 23 },
                    { 411, 3, 1, 1, 22 },
                    { 427, 3, 2, 1, 22 },
                    { 443, 3, 3, 1, 22 },
                    { 459, 3, 4, 1, 22 },
                    { 475, 3, 5, 4, 22 },
                    { 491, 3, 6, 4, 22 },
                    { 507, 3, 7, 3, 22 },
                    { 523, 3, 8, 3, 22 },
                    { 539, 3, 9, 4, 22 },
                    { 555, 3, 10, 4, 22 },
                    { 571, 3, 11, 4, 22 },
                    { 587, 3, 12, 1, 22 },
                    { 19, 1, 1, 2, 23 },
                    { 38, 1, 2, 3, 23 },
                    { 57, 1, 3, 4, 23 },
                    { 95, 1, 5, 4, 23 },
                    { 504, 3, 7, 3, 17 },
                    { 367, 2, 10, 2, 21 },
                    { 339, 2, 8, 3, 21 },
                    { 282, 2, 4, 2, 18 },
                    { 296, 2, 5, 2, 18 },
                    { 310, 2, 6, 2, 18 },
                    { 324, 2, 7, 2, 18 },
                    { 338, 2, 8, 2, 18 },
                    { 352, 2, 9, 2, 18 },
                    { 268, 2, 3, 2, 18 },
                    { 366, 2, 10, 2, 18 },
                    { 394, 2, 12, 2, 18 },
                    { 409, 3, 1, 2, 19 },
                    { 425, 3, 2, 2, 19 },
                    { 441, 3, 3, 2, 19 },
                    { 457, 3, 4, 3, 19 },
                    { 473, 3, 5, 3, 19 },
                    { 380, 2, 11, 2, 18 },
                    { 254, 2, 2, 2, 18 },
                    { 240, 2, 1, 2, 18 },
                    { 224, 1, 12, 3, 18 },
                    { 536, 3, 9, 4, 17 },
                    { 552, 3, 10, 4, 17 },
                    { 568, 3, 11, 2, 17 },
                    { 584, 3, 12, 1, 17 },
                    { 15, 1, 1, 4, 18 },
                    { 34, 1, 2, 4, 18 },
                    { 53, 1, 3, 4, 18 },
                    { 72, 1, 4, 4, 18 },
                    { 91, 1, 5, 3, 18 },
                    { 110, 1, 6, 2, 18 },
                    { 129, 1, 7, 1, 18 },
                    { 148, 1, 8, 1, 18 },
                    { 167, 1, 9, 1, 18 },
                    { 186, 1, 10, 1, 18 },
                    { 205, 1, 11, 2, 18 },
                    { 489, 3, 6, 3, 19 },
                    { 505, 3, 7, 1, 19 },
                    { 521, 3, 8, 1, 19 },
                    { 537, 3, 9, 3, 19 },
                    { 93, 1, 5, 1, 21 },
                    { 112, 1, 6, 2, 21 },
                    { 131, 1, 7, 3, 21 },
                    { 150, 1, 8, 3, 21 },
                    { 169, 1, 9, 4, 21 },
                    { 188, 1, 10, 4, 21 },
                    { 207, 1, 11, 4, 21 },
                    { 226, 1, 12, 4, 21 },
                    { 241, 2, 1, 2, 21 },
                    { 255, 2, 2, 2, 21 },
                    { 269, 2, 3, 3, 21 },
                    { 283, 2, 4, 4, 21 },
                    { 297, 2, 5, 4, 21 },
                    { 311, 2, 6, 4, 21 },
                    { 325, 2, 7, 4, 21 },
                    { 74, 1, 4, 1, 21 },
                    { 353, 2, 9, 3, 21 },
                    { 55, 1, 3, 1, 21 },
                    { 17, 1, 1, 2, 21 },
                    { 553, 3, 10, 3, 19 },
                    { 569, 3, 11, 1, 19 },
                    { 585, 3, 12, 1, 19 },
                    { 16, 1, 1, 1, 20 },
                    { 35, 1, 2, 1, 20 },
                    { 54, 1, 3, 1, 20 },
                    { 73, 1, 4, 2, 20 },
                    { 92, 1, 5, 3, 20 },
                    { 111, 1, 6, 4, 20 },
                    { 130, 1, 7, 4, 20 },
                    { 149, 1, 8, 4, 20 },
                    { 168, 1, 9, 4, 20 },
                    { 187, 1, 10, 4, 20 },
                    { 206, 1, 11, 3, 20 },
                    { 225, 1, 12, 2, 20 },
                    { 36, 1, 2, 1, 21 },
                    { 589, 4, 1, 1, 11 },
                    { 580, 3, 12, 1, 11 },
                    { 564, 3, 11, 1, 11 },
                    { 212, 1, 12, 2, 4 },
                    { 399, 3, 1, 4, 4 },
                    { 415, 3, 2, 4, 4 },
                    { 431, 3, 3, 4, 4 },
                    { 447, 3, 4, 4, 4 },
                    { 463, 3, 5, 2, 4 },
                    { 193, 1, 11, 2, 4 },
                    { 479, 3, 6, 1, 4 },
                    { 511, 3, 8, 1, 4 },
                    { 527, 3, 9, 1, 4 },
                    { 543, 3, 10, 2, 4 },
                    { 559, 3, 11, 2, 4 },
                    { 575, 3, 12, 3, 4 },
                    { 4, 1, 1, 2, 5 },
                    { 495, 3, 7, 1, 4 },
                    { 174, 1, 10, 2, 4 },
                    { 155, 1, 9, 1, 4 },
                    { 136, 1, 8, 2, 4 },
                    { 462, 3, 5, 3, 3 },
                    { 478, 3, 6, 3, 3 },
                    { 494, 3, 7, 1, 3 },
                    { 510, 3, 8, 1, 3 },
                    { 526, 3, 9, 3, 3 },
                    { 542, 3, 10, 3, 3 },
                    { 558, 3, 11, 1, 3 },
                    { 574, 3, 12, 1, 3 },
                    { 3, 1, 1, 1, 4 },
                    { 22, 1, 2, 2, 4 },
                    { 41, 1, 3, 2, 4 },
                    { 60, 1, 4, 3, 4 },
                    { 79, 1, 5, 4, 4 },
                    { 98, 1, 6, 4, 4 },
                    { 117, 1, 7, 3, 4 },
                    { 23, 1, 2, 3, 5 },
                    { 42, 1, 3, 3, 5 },
                    { 61, 1, 4, 4, 5 },
                    { 80, 1, 5, 4, 5 },
                    { 5, 1, 1, 3, 6 },
                    { 24, 1, 2, 3, 6 },
                    { 43, 1, 3, 3, 6 },
                    { 62, 1, 4, 3, 6 },
                    { 81, 1, 5, 4, 6 },
                    { 100, 1, 6, 4, 6 },
                    { 119, 1, 7, 3, 6 },
                    { 138, 1, 8, 2, 6 },
                    { 157, 1, 9, 1, 6 },
                    { 176, 1, 10, 1, 6 },
                    { 195, 1, 11, 2, 6 },
                    { 214, 1, 12, 3, 6 },
                    { 400, 3, 1, 1, 6 },
                    { 416, 3, 2, 1, 6 },
                    { 432, 3, 3, 2, 6 },
                    { 386, 2, 12, 4, 5 },
                    { 446, 3, 4, 3, 3 },
                    { 372, 2, 11, 4, 5 },
                    { 344, 2, 9, 4, 5 },
                    { 99, 1, 6, 4, 5 },
                    { 118, 1, 7, 3, 5 },
                    { 137, 1, 8, 2, 5 },
                    { 156, 1, 9, 1, 5 },
                    { 175, 1, 10, 1, 5 },
                    { 194, 1, 11, 1, 5 },
                    { 213, 1, 12, 1, 5 },
                    { 232, 2, 1, 3, 5 },
                    { 246, 2, 2, 3, 5 },
                    { 260, 2, 3, 2, 5 },
                    { 274, 2, 4, 2, 5 },
                    { 288, 2, 5, 1, 5 },
                    { 302, 2, 6, 1, 5 },
                    { 316, 2, 7, 1, 5 },
                    { 330, 2, 8, 3, 5 },
                    { 358, 2, 10, 4, 5 },
                    { 448, 3, 4, 2, 6 },
                    { 430, 3, 3, 2, 3 },
                    { 398, 3, 1, 2, 3 },
                    { 341, 2, 9, 4, 1 },
                    { 355, 2, 10, 4, 1 },
                    { 369, 2, 11, 4, 1 },
                    { 383, 2, 12, 4, 1 },
                    { 397, 3, 1, 2, 1 },
                    { 413, 3, 2, 2, 1 },
                    { 327, 2, 8, 1, 1 },
                    { 429, 3, 3, 2, 1 },
                    { 461, 3, 5, 2, 1 },
                    { 477, 3, 6, 1, 1 },
                    { 493, 3, 7, 1, 1 },
                    { 509, 3, 8, 1, 1 },
                    { 525, 3, 9, 1, 1 },
                    { 541, 3, 10, 1, 1 },
                    { 445, 3, 4, 2, 1 },
                    { 313, 2, 7, 1, 1 },
                    { 299, 2, 6, 1, 1 },
                    { 285, 2, 5, 1, 1 },
                    { 20, 1, 2, 3, 1 },
                    { 39, 1, 3, 3, 1 },
                    { 58, 1, 4, 3, 1 },
                    { 77, 1, 5, 4, 1 },
                    { 96, 1, 6, 4, 1 },
                    { 115, 1, 7, 3, 1 },
                    { 134, 1, 8, 2, 1 },
                    { 153, 1, 9, 1, 1 },
                    { 172, 1, 10, 1, 1 },
                    { 191, 1, 11, 1, 1 },
                    { 210, 1, 12, 1, 1 },
                    { 229, 2, 1, 3, 1 },
                    { 243, 2, 2, 3, 1 },
                    { 257, 2, 3, 2, 1 },
                    { 271, 2, 4, 1, 1 },
                    { 557, 3, 11, 1, 1 },
                    { 573, 3, 12, 2, 1 },
                    { 230, 2, 1, 4, 2 },
                    { 244, 2, 2, 4, 2 },
                    { 173, 1, 10, 3, 3 },
                    { 192, 1, 11, 3, 3 },
                    { 211, 1, 12, 3, 3 },
                    { 231, 2, 1, 2, 3 },
                    { 245, 2, 2, 2, 3 },
                    { 259, 2, 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "DestSpeciesMonth",
                columns: new[] { "DestSpeciesMonthId", "DSMDestinationId", "DSMMonthId", "DSMRatingId", "DSMSpeciesId" },
                values: new object[,]
                {
                    { 273, 2, 4, 4, 3 },
                    { 287, 2, 5, 4, 3 },
                    { 301, 2, 6, 4, 3 },
                    { 315, 2, 7, 4, 3 },
                    { 329, 2, 8, 4, 3 },
                    { 343, 2, 9, 4, 3 },
                    { 357, 2, 10, 3, 3 },
                    { 371, 2, 11, 2, 3 },
                    { 385, 2, 12, 2, 3 },
                    { 154, 1, 9, 3, 3 },
                    { 414, 3, 2, 2, 3 },
                    { 135, 1, 8, 3, 3 },
                    { 97, 1, 6, 3, 3 },
                    { 258, 2, 3, 4, 2 },
                    { 272, 2, 4, 4, 2 },
                    { 286, 2, 5, 4, 2 },
                    { 300, 2, 6, 4, 2 },
                    { 314, 2, 7, 4, 2 },
                    { 328, 2, 8, 4, 2 },
                    { 342, 2, 9, 4, 2 },
                    { 356, 2, 10, 4, 2 },
                    { 370, 2, 11, 4, 2 },
                    { 384, 2, 12, 4, 2 },
                    { 2, 1, 1, 3, 3 },
                    { 21, 1, 2, 3, 3 },
                    { 40, 1, 3, 3, 3 },
                    { 59, 1, 4, 3, 3 },
                    { 78, 1, 5, 3, 3 },
                    { 116, 1, 7, 3, 3 },
                    { 464, 3, 5, 3, 6 },
                    { 480, 3, 6, 3, 6 },
                    { 496, 3, 7, 3, 6 },
                    { 122, 1, 7, 3, 10 },
                    { 141, 1, 8, 3, 10 },
                    { 160, 1, 9, 3, 10 },
                    { 179, 1, 10, 3, 10 },
                    { 198, 1, 11, 3, 10 },
                    { 217, 1, 12, 3, 10 },
                    { 103, 1, 6, 2, 10 },
                    { 403, 3, 1, 1, 10 },
                    { 435, 3, 3, 1, 10 },
                    { 451, 3, 4, 1, 10 },
                    { 467, 3, 5, 1, 10 },
                    { 483, 3, 6, 1, 10 },
                    { 499, 3, 7, 2, 10 },
                    { 515, 3, 8, 3, 10 },
                    { 419, 3, 2, 1, 10 },
                    { 84, 1, 5, 1, 10 },
                    { 65, 1, 4, 1, 10 },
                    { 46, 1, 3, 1, 10 },
                    { 389, 2, 12, 1, 9 },
                    { 402, 3, 1, 1, 9 },
                    { 418, 3, 2, 1, 9 },
                    { 434, 3, 3, 1, 9 },
                    { 450, 3, 4, 1, 9 },
                    { 466, 3, 5, 2, 9 },
                    { 482, 3, 6, 3, 9 },
                    { 498, 3, 7, 4, 9 },
                    { 514, 3, 8, 4, 9 },
                    { 530, 3, 9, 3, 9 },
                    { 546, 3, 10, 3, 9 },
                    { 562, 3, 11, 1, 9 },
                    { 578, 3, 12, 1, 9 },
                    { 8, 1, 1, 2, 10 },
                    { 27, 1, 2, 2, 10 },
                    { 531, 3, 9, 4, 10 },
                    { 547, 3, 10, 4, 10 },
                    { 563, 3, 11, 1, 10 },
                    { 579, 3, 12, 1, 10 },
                    { 334, 2, 8, 4, 11 },
                    { 348, 2, 9, 2, 11 },
                    { 362, 2, 10, 1, 11 },
                    { 376, 2, 11, 1, 11 },
                    { 390, 2, 12, 1, 11 },
                    { 404, 3, 1, 1, 11 },
                    { 420, 3, 2, 1, 11 },
                    { 436, 3, 3, 1, 11 },
                    { 452, 3, 4, 1, 11 },
                    { 468, 3, 5, 1, 11 },
                    { 484, 3, 6, 1, 11 },
                    { 500, 3, 7, 2, 11 },
                    { 516, 3, 8, 3, 11 },
                    { 532, 3, 9, 4, 11 },
                    { 548, 3, 10, 4, 11 },
                    { 320, 2, 7, 4, 11 },
                    { 375, 2, 11, 1, 9 },
                    { 306, 2, 6, 4, 11 },
                    { 278, 2, 4, 3, 11 },
                    { 9, 1, 1, 2, 11 },
                    { 28, 1, 2, 1, 11 },
                    { 47, 1, 3, 1, 11 },
                    { 66, 1, 4, 2, 11 },
                    { 85, 1, 5, 3, 11 },
                    { 104, 1, 6, 3, 11 },
                    { 123, 1, 7, 4, 11 },
                    { 142, 1, 8, 4, 11 },
                    { 161, 1, 9, 4, 11 },
                    { 180, 1, 10, 4, 11 },
                    { 199, 1, 11, 3, 11 },
                    { 218, 1, 12, 3, 11 },
                    { 236, 2, 1, 1, 11 },
                    { 250, 2, 2, 2, 11 },
                    { 264, 2, 3, 2, 11 },
                    { 292, 2, 5, 4, 11 },
                    { 361, 2, 10, 1, 9 },
                    { 347, 2, 9, 2, 9 },
                    { 333, 2, 8, 3, 9 },
                    { 44, 1, 3, 2, 8 },
                    { 63, 1, 4, 3, 8 },
                    { 82, 1, 5, 4, 8 },
                    { 101, 1, 6, 4, 8 },
                    { 120, 1, 7, 4, 8 },
                    { 139, 1, 8, 3, 8 },
                    { 158, 1, 9, 1, 8 },
                    { 177, 1, 10, 1, 8 },
                    { 196, 1, 11, 2, 8 },
                    { 215, 1, 12, 3, 8 },
                    { 234, 2, 1, 4, 8 },
                    { 248, 2, 2, 4, 8 },
                    { 262, 2, 3, 2, 8 },
                    { 276, 2, 4, 1, 8 },
                    { 290, 2, 5, 1, 8 },
                    { 25, 1, 2, 2, 8 },
                    { 304, 2, 6, 1, 8 },
                    { 6, 1, 1, 3, 8 },
                    { 373, 2, 11, 4, 7 },
                    { 512, 3, 8, 3, 6 },
                    { 528, 3, 9, 3, 6 },
                    { 544, 3, 10, 3, 6 },
                    { 560, 3, 11, 1, 6 },
                    { 576, 3, 12, 1, 6 },
                    { 233, 2, 1, 4, 7 },
                    { 247, 2, 2, 3, 7 },
                    { 261, 2, 3, 2, 7 },
                    { 275, 2, 4, 1, 7 },
                    { 289, 2, 5, 1, 7 },
                    { 303, 2, 6, 1, 7 },
                    { 317, 2, 7, 1, 7 },
                    { 331, 2, 8, 1, 7 },
                    { 345, 2, 9, 2, 7 },
                    { 359, 2, 10, 3, 7 },
                    { 387, 2, 12, 4, 7 },
                    { 572, 3, 11, 1, 23 },
                    { 318, 2, 7, 1, 8 },
                    { 346, 2, 9, 1, 8 },
                    { 83, 1, 5, 2, 9 },
                    { 102, 1, 6, 3, 9 },
                    { 121, 1, 7, 4, 9 },
                    { 140, 1, 8, 4, 9 },
                    { 159, 1, 9, 4, 9 },
                    { 178, 1, 10, 4, 9 },
                    { 197, 1, 11, 4, 9 },
                    { 216, 1, 12, 3, 9 },
                    { 235, 2, 1, 1, 9 },
                    { 249, 2, 2, 2, 9 },
                    { 263, 2, 3, 3, 9 },
                    { 277, 2, 4, 4, 9 },
                    { 291, 2, 5, 4, 9 },
                    { 305, 2, 6, 4, 9 },
                    { 319, 2, 7, 4, 9 },
                    { 64, 1, 4, 2, 9 },
                    { 332, 2, 8, 1, 8 },
                    { 45, 1, 3, 1, 9 },
                    { 7, 1, 1, 3, 9 },
                    { 360, 2, 10, 3, 8 },
                    { 374, 2, 11, 4, 8 },
                    { 388, 2, 12, 4, 8 },
                    { 401, 3, 1, 4, 8 },
                    { 417, 3, 2, 4, 8 },
                    { 433, 3, 3, 4, 8 },
                    { 449, 3, 4, 3, 8 },
                    { 465, 3, 5, 1, 8 },
                    { 481, 3, 6, 1, 8 },
                    { 497, 3, 7, 1, 8 },
                    { 513, 3, 8, 1, 8 },
                    { 529, 3, 9, 1, 8 },
                    { 545, 3, 10, 1, 8 },
                    { 561, 3, 11, 2, 8 },
                    { 577, 3, 12, 4, 8 },
                    { 26, 1, 2, 2, 9 },
                    { 588, 3, 12, 2, 23 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdentityUserId",
                table: "Admin",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DestSpeciesMonth_DSMDestinationId",
                table: "DestSpeciesMonth",
                column: "DSMDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DestSpeciesMonth_DSMMonthId",
                table: "DestSpeciesMonth",
                column: "DSMMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_DestSpeciesMonth_DSMRatingId",
                table: "DestSpeciesMonth",
                column: "DSMRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_DestSpeciesMonth_DSMSpeciesId",
                table: "DestSpeciesMonth",
                column: "DSMSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Explorer_IdentityUserId",
                table: "Explorer",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DestSpeciesMonth");

            migrationBuilder.DropTable(
                name: "Explorer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
