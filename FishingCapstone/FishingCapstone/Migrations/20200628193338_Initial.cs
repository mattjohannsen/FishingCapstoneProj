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
                    DestinationLong = table.Column<string>(nullable: true),
                    DestinationExample = table.Column<string>(nullable: true)
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
                    SpeciesName = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    TrophyExample = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExplorerId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    TripName = table.Column<string>(nullable: true),
                    TripGuideService = table.Column<string>(nullable: true),
                    TripMonthId = table.Column<int>(nullable: false),
                    TripStart = table.Column<DateTime>(nullable: true),
                    TripEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trip_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Explorer_ExplorerId",
                        column: x => x.ExplorerId,
                        principalTable: "Explorer",
                        principalColumn: "ExplorerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Month_TripMonthId",
                        column: x => x.TripMonthId,
                        principalTable: "Month",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    PhotoDate = table.Column<string>(nullable: true),
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
                values: new object[,]
                {
                    { "ac1be369-b79b-4663-8f01-91237f372ab5", "27e4b026-cb15-460f-84ba-3944c9f539df", "Explorer", "EXPLORER" },
                    { "6660616e-23a2-4901-b92f-6b33fe2dd850", "088a6cc0-f676-46ce-a93c-2f0f4fe6cd34", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "DestinationExample", "DestinationLat", "DestinationLong", "DestinationName" },
                values: new object[,]
                {
                    { 7, null, "24.898941", "-80.658778", "Islamorada, FL" },
                    { 6, null, "43.4706", "-87.9506", "Fredonia WI" },
                    { 1, null, "22.8822", "-109.91203", "Cabo San Lucas, MX" },
                    { 4, null, "43.412800", "-88.189249", "West Bend, WI" },
                    { 3, null, "24.167785", "-110.310101", "La Paz, MX" },
                    { 5, null, "43.4317", "-88.0465", "Newburg, WI" },
                    { 2, null, "20.468355", "-86.978845", "Cozumel, MX" }
                });

            migrationBuilder.InsertData(
                table: "Month",
                columns: new[] { "MonthId", "MonthName" },
                values: new object[,]
                {
                    { 12, "December" },
                    { 11, "November" },
                    { 10, "October" },
                    { 9, "September" },
                    { 8, "August" },
                    { 7, "July" },
                    { 5, "May" },
                    { 4, "April" },
                    { 3, "March" },
                    { 2, "February" },
                    { 1, "January" },
                    { 6, "June" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "RatingName", "RatingNumber" },
                values: new object[,]
                {
                    { 4, "Best", 4 },
                    { 3, "Good", 3 },
                    { 2, "Fair", 2 },
                    { 1, "Poor", 1 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "SpeciesName", "Thumbnail", "TrophyExample" },
                values: new object[,]
                {
                    { 30, "Swordfish", "swordfish.jpg", null },
                    { 29, "Sea Trout", "seatrout.jpg", null },
                    { 28, "Cobia", "cobia.jpg", null },
                    { 27, "Tuna - Blackfin", "tunablackfin.jpg", null },
                    { 26, "Tarpon", "tarpon.jpg", null },
                    { 25, "Permit", "permit.jpg", null },
                    { 24, "Bonefish", "bonefish.jpg", null },
                    { 23, "Yellowtail", "yellowtail.jpg", null },
                    { 22, "Wahoo", "wahoo.jpg", null },
                    { 21, "Tuna - Yellowfin", "tunayellowfin.jpg", null },
                    { 20, "Snook", "snook.jpg", null },
                    { 19, "Skipjack", "skipjack.jpg", null },
                    { 18, "Shark", "shark.jpg", null },
                    { 17, "Sailfish", "sailfish.jpg", null },
                    { 7, "Kingfish", "kingfish.jpg", null },
                    { 15, "Red Snapper", "redsnapper.jpg", null },
                    { 14, "Pargo - Dogtooth Snapper", "pargo.jpg", null },
                    { 13, "Marlin - White", "marlinwhite.jpg", null },
                    { 12, "Marlin - Striped", "marlinstriped.jpg", null },
                    { 11, "Marlin - Blue", "marlinblue.jpg", null },
                    { 10, "Marlin - Black", "marlinblack.jpg", null },
                    { 9, "Mahi Mahi - Dorado", "mahimahi.jpg", null },
                    { 8, "Mackerel - Sierra", "mackeralsierra.jpg", null },
                    { 6, "Jack Crevalle", "jackcreavalle.jpg", null },
                    { 4, "Cabrilla", "cabrilla.jpg", null },
                    { 3, "Bonito", "bonito.jpg", null },
                    { 2, "Barracuda", "barracuda.jpg", null },
                    { 1, "Amberjack", "amberjack.jpg", null },
                    { 16, "Roosterfish", "roosterfish.jpg", null },
                    { 5, "Grouper", "grouper.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "DestSpeciesMonth",
                columns: new[] { "DestSpeciesMonthId", "DSMDestinationId", "DSMMonthId", "DSMRatingId", "DSMSpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 1 },
                    { 110, 1, 6, 2, 18 },
                    { 129, 1, 7, 1, 18 },
                    { 148, 1, 8, 1, 18 },
                    { 167, 1, 9, 1, 18 },
                    { 186, 1, 10, 1, 18 },
                    { 205, 1, 11, 2, 18 },
                    { 224, 1, 12, 3, 18 },
                    { 238, 2, 1, 2, 18 },
                    { 256, 2, 2, 2, 18 },
                    { 274, 2, 3, 2, 18 },
                    { 292, 2, 4, 2, 18 },
                    { 91, 1, 5, 3, 18 },
                    { 310, 2, 5, 2, 18 },
                    { 346, 2, 7, 2, 18 },
                    { 364, 2, 8, 2, 18 },
                    { 382, 2, 9, 2, 18 },
                    { 400, 2, 10, 2, 18 },
                    { 418, 2, 11, 2, 18 },
                    { 436, 2, 12, 2, 18 },
                    { 681, 7, 1, 4, 18 },
                    { 700, 7, 2, 4, 18 },
                    { 719, 7, 3, 4, 18 },
                    { 738, 7, 4, 2, 18 },
                    { 757, 7, 5, 4, 18 },
                    { 328, 2, 6, 2, 18 },
                    { 776, 7, 6, 2, 18 },
                    { 72, 1, 4, 4, 18 },
                    { 34, 1, 2, 4, 18 },
                    { 472, 3, 2, 1, 17 },
                    { 488, 3, 3, 1, 17 },
                    { 504, 3, 4, 1, 17 },
                    { 520, 3, 5, 2, 17 },
                    { 536, 3, 6, 3, 17 },
                    { 552, 3, 7, 3, 17 },
                    { 568, 3, 8, 4, 17 },
                    { 584, 3, 9, 4, 17 },
                    { 600, 3, 10, 4, 17 },
                    { 616, 3, 11, 2, 17 },
                    { 632, 3, 12, 1, 17 },
                    { 53, 1, 3, 4, 18 },
                    { 680, 7, 1, 1, 17 },
                    { 718, 7, 3, 4, 17 },
                    { 737, 7, 4, 4, 17 },
                    { 756, 7, 5, 4, 17 },
                    { 775, 7, 6, 3, 17 },
                    { 794, 7, 7, 3, 17 },
                    { 813, 7, 8, 2, 17 },
                    { 832, 7, 9, 2, 17 },
                    { 851, 7, 10, 1, 17 },
                    { 870, 7, 11, 1, 17 },
                    { 889, 7, 12, 1, 17 },
                    { 15, 1, 1, 4, 18 },
                    { 699, 7, 2, 3, 17 },
                    { 456, 3, 1, 1, 17 },
                    { 795, 7, 7, 4, 18 },
                    { 833, 7, 9, 4, 18 },
                    { 261, 2, 2, 3, 20 },
                    { 279, 2, 3, 4, 20 },
                    { 297, 2, 4, 4, 20 },
                    { 315, 2, 5, 4, 20 },
                    { 333, 2, 6, 4, 20 },
                    { 351, 2, 7, 4, 20 },
                    { 369, 2, 8, 4, 20 },
                    { 387, 2, 9, 3, 20 },
                    { 405, 2, 10, 3, 20 },
                    { 423, 2, 11, 3, 20 },
                    { 441, 2, 12, 3, 20 },
                    { 243, 2, 1, 3, 20 },
                    { 17, 1, 1, 2, 21 },
                    { 55, 1, 3, 1, 21 },
                    { 74, 1, 4, 1, 21 },
                    { 93, 1, 5, 1, 21 },
                    { 112, 1, 6, 2, 21 },
                    { 131, 1, 7, 3, 21 },
                    { 150, 1, 8, 3, 21 },
                    { 169, 1, 9, 4, 21 },
                    { 188, 1, 10, 4, 21 },
                    { 207, 1, 11, 4, 21 },
                    { 226, 1, 12, 4, 21 },
                    { 240, 2, 1, 2, 21 },
                    { 36, 1, 2, 1, 21 },
                    { 814, 7, 8, 2, 18 },
                    { 225, 1, 12, 2, 20 },
                    { 187, 1, 10, 4, 20 },
                    { 852, 7, 10, 4, 18 },
                    { 871, 7, 11, 4, 18 },
                    { 890, 7, 12, 4, 18 },
                    { 457, 3, 1, 2, 19 },
                    { 473, 3, 2, 2, 19 },
                    { 489, 3, 3, 2, 19 },
                    { 505, 3, 4, 3, 19 },
                    { 521, 3, 5, 3, 19 },
                    { 537, 3, 6, 3, 19 },
                    { 553, 3, 7, 1, 19 },
                    { 569, 3, 8, 1, 19 },
                    { 206, 1, 11, 3, 20 },
                    { 585, 3, 9, 3, 19 },
                    { 617, 3, 11, 1, 19 },
                    { 633, 3, 12, 1, 19 },
                    { 16, 1, 1, 1, 20 },
                    { 35, 1, 2, 1, 20 },
                    { 54, 1, 3, 1, 20 },
                    { 73, 1, 4, 2, 20 },
                    { 92, 1, 5, 3, 20 },
                    { 111, 1, 6, 4, 20 },
                    { 130, 1, 7, 4, 20 },
                    { 149, 1, 8, 4, 20 },
                    { 168, 1, 9, 4, 20 },
                    { 601, 3, 10, 3, 19 },
                    { 435, 2, 12, 1, 17 },
                    { 417, 2, 11, 1, 17 },
                    { 399, 2, 10, 1, 17 },
                    { 12, 1, 1, 3, 15 },
                    { 31, 1, 2, 3, 15 },
                    { 50, 1, 3, 3, 15 },
                    { 69, 1, 4, 4, 15 },
                    { 88, 1, 5, 4, 15 },
                    { 107, 1, 6, 4, 15 },
                    { 126, 1, 7, 4, 15 },
                    { 145, 1, 8, 4, 15 },
                    { 164, 1, 9, 4, 15 },
                    { 183, 1, 10, 3, 15 },
                    { 202, 1, 11, 2, 15 },
                    { 630, 3, 12, 1, 14 },
                    { 221, 1, 12, 3, 15 },
                    { 257, 2, 2, 1, 15 },
                    { 275, 2, 3, 1, 15 },
                    { 293, 2, 4, 1, 15 },
                    { 311, 2, 5, 1, 15 },
                    { 329, 2, 6, 1, 15 },
                    { 347, 2, 7, 1, 15 },
                    { 365, 2, 8, 1, 15 },
                    { 383, 2, 9, 3, 15 },
                    { 401, 2, 10, 4, 15 },
                    { 419, 2, 11, 4, 15 },
                    { 437, 2, 12, 4, 15 },
                    { 239, 2, 1, 3, 15 },
                    { 689, 7, 1, 4, 15 },
                    { 614, 3, 11, 1, 14 },
                    { 582, 3, 9, 1, 14 },
                    { 831, 7, 9, 1, 13 },
                    { 850, 7, 10, 1, 13 },
                    { 869, 7, 11, 1, 13 },
                    { 888, 7, 12, 1, 13 },
                    { 11, 1, 1, 3, 14 },
                    { 30, 1, 2, 3, 14 },
                    { 49, 1, 3, 3, 14 },
                    { 68, 1, 4, 4, 14 },
                    { 87, 1, 5, 4, 14 },
                    { 106, 1, 6, 4, 14 },
                    { 125, 1, 7, 4, 14 },
                    { 598, 3, 10, 1, 14 },
                    { 144, 1, 8, 4, 14 },
                    { 182, 1, 10, 3, 14 },
                    { 201, 1, 11, 2, 14 },
                    { 220, 1, 12, 3, 14 },
                    { 454, 3, 1, 1, 14 },
                    { 470, 3, 2, 1, 14 },
                    { 486, 3, 3, 2, 14 },
                    { 502, 3, 4, 4, 14 },
                    { 518, 3, 5, 4, 14 },
                    { 534, 3, 6, 2, 14 },
                    { 550, 3, 7, 1, 14 },
                    { 566, 3, 8, 1, 14 },
                    { 163, 1, 9, 4, 14 },
                    { 708, 7, 2, 4, 15 },
                    { 727, 7, 3, 4, 15 },
                    { 746, 7, 4, 4, 15 },
                    { 599, 3, 10, 2, 16 },
                    { 615, 3, 11, 1, 16 },
                    { 631, 3, 12, 1, 16 },
                    { 14, 1, 1, 2, 17 },
                    { 33, 1, 2, 1, 17 },
                    { 52, 1, 3, 1, 17 },
                    { 71, 1, 4, 1, 17 },
                    { 90, 1, 5, 2, 17 },
                    { 109, 1, 6, 2, 17 },
                    { 128, 1, 7, 3, 17 },
                    { 147, 1, 8, 3, 17 },
                    { 583, 3, 9, 2, 16 },
                    { 166, 1, 9, 4, 17 },
                    { 204, 1, 11, 4, 17 },
                    { 223, 1, 12, 3, 17 },
                    { 237, 2, 1, 2, 17 },
                    { 255, 2, 2, 3, 17 },
                    { 273, 2, 3, 4, 17 },
                    { 291, 2, 4, 4, 17 },
                    { 309, 2, 5, 4, 17 },
                    { 327, 2, 6, 4, 17 },
                    { 345, 2, 7, 4, 17 },
                    { 363, 2, 8, 3, 17 },
                    { 381, 2, 9, 2, 17 },
                    { 185, 1, 10, 4, 17 },
                    { 567, 3, 8, 2, 16 },
                    { 551, 3, 7, 4, 16 },
                    { 535, 3, 6, 4, 16 },
                    { 765, 7, 5, 4, 15 },
                    { 784, 7, 6, 3, 15 },
                    { 803, 7, 7, 3, 15 },
                    { 822, 7, 8, 3, 15 },
                    { 841, 7, 9, 3, 15 },
                    { 860, 7, 10, 4, 15 },
                    { 879, 7, 11, 4, 15 },
                    { 898, 7, 12, 4, 15 },
                    { 13, 1, 1, 3, 16 },
                    { 32, 1, 2, 3, 16 },
                    { 51, 1, 3, 3, 16 },
                    { 70, 1, 4, 3, 16 },
                    { 89, 1, 5, 4, 16 },
                    { 108, 1, 6, 4, 16 },
                    { 127, 1, 7, 4, 16 },
                    { 146, 1, 8, 4, 16 },
                    { 165, 1, 9, 2, 16 },
                    { 184, 1, 10, 2, 16 },
                    { 203, 1, 11, 3, 16 },
                    { 222, 1, 12, 3, 16 },
                    { 455, 3, 1, 1, 16 },
                    { 471, 3, 2, 1, 16 },
                    { 487, 3, 3, 2, 16 },
                    { 503, 3, 4, 3, 16 },
                    { 519, 3, 5, 4, 16 },
                    { 258, 2, 2, 2, 21 },
                    { 812, 7, 8, 3, 13 },
                    { 276, 2, 3, 3, 21 },
                    { 312, 2, 5, 4, 21 },
                    { 723, 7, 3, 4, 25 },
                    { 742, 7, 4, 4, 25 },
                    { 761, 7, 5, 3, 25 },
                    { 780, 7, 6, 1, 25 },
                    { 799, 7, 7, 2, 25 },
                    { 818, 7, 8, 3, 25 },
                    { 837, 7, 9, 4, 25 },
                    { 856, 7, 10, 4, 25 },
                    { 875, 7, 11, 3, 25 },
                    { 894, 7, 12, 1, 25 },
                    { 246, 2, 1, 2, 26 },
                    { 704, 7, 2, 2, 25 },
                    { 264, 2, 2, 2, 26 },
                    { 300, 2, 4, 2, 26 },
                    { 318, 2, 5, 2, 26 },
                    { 336, 2, 6, 2, 26 },
                    { 354, 2, 7, 2, 26 },
                    { 372, 2, 8, 2, 26 },
                    { 390, 2, 9, 2, 26 },
                    { 408, 2, 10, 2, 26 },
                    { 426, 2, 11, 2, 26 },
                    { 444, 2, 12, 2, 26 },
                    { 686, 7, 1, 1, 26 },
                    { 705, 7, 2, 2, 26 },
                    { 282, 2, 3, 2, 26 },
                    { 724, 7, 3, 2, 26 },
                    { 685, 7, 1, 1, 25 },
                    { 425, 2, 11, 3, 25 },
                    { 424, 2, 11, 4, 24 },
                    { 442, 2, 12, 4, 24 },
                    { 684, 7, 1, 1, 24 },
                    { 703, 7, 2, 2, 24 },
                    { 722, 7, 3, 4, 24 },
                    { 741, 7, 4, 4, 24 },
                    { 760, 7, 5, 3, 24 },
                    { 779, 7, 6, 2, 24 },
                    { 798, 7, 7, 1, 24 },
                    { 817, 7, 8, 1, 24 },
                    { 836, 7, 9, 3, 24 },
                    { 443, 2, 12, 3, 25 },
                    { 855, 7, 10, 4, 24 },
                    { 893, 7, 12, 4, 24 },
                    { 245, 2, 1, 2, 25 },
                    { 263, 2, 2, 2, 25 },
                    { 281, 2, 3, 4, 25 },
                    { 299, 2, 4, 4, 25 },
                    { 317, 2, 5, 4, 25 },
                    { 335, 2, 6, 4, 25 },
                    { 353, 2, 7, 4, 25 },
                    { 371, 2, 8, 4, 25 },
                    { 389, 2, 9, 3, 25 },
                    { 407, 2, 10, 3, 25 },
                    { 874, 7, 11, 4, 24 },
                    { 406, 2, 10, 4, 24 },
                    { 743, 7, 4, 4, 26 },
                    { 781, 7, 6, 3, 26 },
                    { 878, 7, 11, 3, 28 },
                    { 897, 7, 12, 4, 28 },
                    { 690, 7, 1, 4, 29 },
                    { 709, 7, 2, 4, 29 },
                    { 728, 7, 3, 3, 29 },
                    { 747, 7, 4, 2, 29 },
                    { 766, 7, 5, 1, 29 },
                    { 785, 7, 6, 1, 29 },
                    { 804, 7, 7, 1, 29 },
                    { 823, 7, 8, 2, 29 },
                    { 842, 7, 9, 2, 29 },
                    { 859, 7, 10, 2, 28 },
                    { 861, 7, 10, 3, 29 },
                    { 899, 7, 12, 4, 29 },
                    { 691, 7, 1, 1, 30 },
                    { 710, 7, 2, 1, 30 },
                    { 729, 7, 3, 2, 30 },
                    { 748, 7, 4, 3, 30 },
                    { 767, 7, 5, 4, 30 },
                    { 786, 7, 6, 4, 30 },
                    { 805, 7, 7, 4, 30 },
                    { 824, 7, 8, 4, 30 },
                    { 843, 7, 9, 4, 30 },
                    { 862, 7, 10, 3, 30 },
                    { 880, 7, 11, 4, 29 },
                    { 762, 7, 5, 4, 26 },
                    { 840, 7, 9, 1, 28 },
                    { 802, 7, 7, 1, 28 },
                    { 800, 7, 7, 1, 26 },
                    { 819, 7, 8, 2, 26 },
                    { 838, 7, 9, 4, 26 },
                    { 857, 7, 10, 4, 26 },
                    { 876, 7, 11, 2, 26 },
                    { 895, 7, 12, 1, 26 },
                    { 687, 7, 1, 1, 27 },
                    { 706, 7, 2, 2, 27 },
                    { 725, 7, 3, 3, 27 },
                    { 744, 7, 4, 4, 27 },
                    { 763, 7, 5, 4, 27 },
                    { 821, 7, 8, 1, 28 },
                    { 782, 7, 6, 3, 27 },
                    { 820, 7, 8, 1, 27 },
                    { 839, 7, 9, 3, 27 },
                    { 858, 7, 10, 4, 27 },
                    { 877, 7, 11, 4, 27 },
                    { 896, 7, 12, 2, 27 },
                    { 688, 7, 1, 4, 28 },
                    { 707, 7, 2, 4, 28 },
                    { 726, 7, 3, 4, 28 },
                    { 745, 7, 4, 3, 28 },
                    { 764, 7, 5, 2, 28 },
                    { 783, 7, 6, 1, 28 },
                    { 801, 7, 7, 1, 27 },
                    { 388, 2, 9, 4, 24 },
                    { 370, 2, 8, 4, 24 },
                    { 352, 2, 7, 4, 24 },
                    { 853, 7, 10, 3, 21 },
                    { 872, 7, 11, 3, 21 },
                    { 891, 7, 12, 4, 21 },
                    { 18, 1, 1, 4, 22 },
                    { 37, 1, 2, 2, 22 },
                    { 56, 1, 3, 1, 22 },
                    { 75, 1, 4, 1, 22 },
                    { 94, 1, 5, 2, 22 },
                    { 113, 1, 6, 2, 22 },
                    { 132, 1, 7, 3, 22 },
                    { 151, 1, 8, 3, 22 },
                    { 834, 7, 9, 3, 21 },
                    { 170, 1, 9, 4, 22 },
                    { 208, 1, 11, 4, 22 },
                    { 227, 1, 12, 4, 22 },
                    { 241, 2, 1, 4, 22 },
                    { 259, 2, 2, 3, 22 },
                    { 277, 2, 3, 3, 22 },
                    { 295, 2, 4, 3, 22 },
                    { 313, 2, 5, 3, 22 },
                    { 331, 2, 6, 3, 22 },
                    { 349, 2, 7, 3, 22 },
                    { 367, 2, 8, 2, 22 },
                    { 385, 2, 9, 1, 22 },
                    { 189, 1, 10, 4, 22 },
                    { 403, 2, 10, 2, 22 },
                    { 815, 7, 8, 3, 21 },
                    { 777, 7, 6, 1, 21 },
                    { 330, 2, 6, 4, 21 },
                    { 348, 2, 7, 4, 21 },
                    { 366, 2, 8, 3, 21 },
                    { 384, 2, 9, 3, 21 },
                    { 402, 2, 10, 2, 21 },
                    { 420, 2, 11, 2, 21 },
                    { 438, 2, 12, 2, 21 },
                    { 458, 3, 1, 1, 21 },
                    { 474, 3, 2, 1, 21 },
                    { 490, 3, 3, 1, 21 },
                    { 506, 3, 4, 1, 21 },
                    { 796, 7, 7, 1, 21 },
                    { 522, 3, 5, 2, 21 },
                    { 554, 3, 7, 1, 21 },
                    { 570, 3, 8, 3, 21 },
                    { 586, 3, 9, 4, 21 },
                    { 602, 3, 10, 4, 21 },
                    { 618, 3, 11, 2, 21 },
                    { 634, 3, 12, 1, 21 },
                    { 682, 7, 1, 4, 21 },
                    { 701, 7, 2, 2, 21 },
                    { 720, 7, 3, 3, 21 },
                    { 739, 7, 4, 1, 21 },
                    { 758, 7, 5, 1, 21 },
                    { 538, 3, 6, 2, 21 },
                    { 421, 2, 11, 4, 22 },
                    { 439, 2, 12, 4, 22 },
                    { 459, 3, 1, 1, 22 },
                    { 133, 1, 7, 2, 23 },
                    { 152, 1, 8, 1, 23 },
                    { 171, 1, 9, 1, 23 },
                    { 190, 1, 10, 1, 23 },
                    { 209, 1, 11, 1, 23 },
                    { 228, 1, 12, 1, 23 },
                    { 460, 3, 1, 2, 23 },
                    { 476, 3, 2, 2, 23 },
                    { 492, 3, 3, 2, 23 },
                    { 508, 3, 4, 2, 23 },
                    { 524, 3, 5, 2, 23 },
                    { 114, 1, 6, 3, 23 },
                    { 540, 3, 6, 1, 23 },
                    { 572, 3, 8, 1, 23 },
                    { 588, 3, 9, 1, 23 },
                    { 604, 3, 10, 1, 23 },
                    { 620, 3, 11, 1, 23 },
                    { 636, 3, 12, 2, 23 },
                    { 244, 2, 1, 4, 24 },
                    { 262, 2, 2, 4, 24 },
                    { 280, 2, 3, 4, 24 },
                    { 298, 2, 4, 4, 24 },
                    { 316, 2, 5, 4, 24 },
                    { 334, 2, 6, 4, 24 },
                    { 556, 3, 7, 1, 23 }
                });

            migrationBuilder.InsertData(
                table: "DestSpeciesMonth",
                columns: new[] { "DestSpeciesMonthId", "DSMDestinationId", "DSMMonthId", "DSMRatingId", "DSMSpeciesId" },
                values: new object[,]
                {
                    { 95, 1, 5, 4, 23 },
                    { 76, 1, 4, 4, 23 },
                    { 57, 1, 3, 4, 23 },
                    { 475, 3, 2, 1, 22 },
                    { 491, 3, 3, 1, 22 },
                    { 507, 3, 4, 1, 22 },
                    { 523, 3, 5, 4, 22 },
                    { 539, 3, 6, 4, 22 },
                    { 555, 3, 7, 3, 22 },
                    { 571, 3, 8, 3, 22 },
                    { 587, 3, 9, 4, 22 },
                    { 603, 3, 10, 4, 22 },
                    { 619, 3, 11, 4, 22 },
                    { 635, 3, 12, 1, 22 },
                    { 683, 7, 1, 1, 22 },
                    { 702, 7, 2, 1, 22 },
                    { 721, 7, 3, 1, 22 },
                    { 740, 7, 4, 2, 22 },
                    { 759, 7, 5, 3, 22 },
                    { 778, 7, 6, 4, 22 },
                    { 797, 7, 7, 4, 22 },
                    { 816, 7, 8, 4, 22 },
                    { 835, 7, 9, 2, 22 },
                    { 854, 7, 10, 1, 22 },
                    { 873, 7, 11, 1, 22 },
                    { 892, 7, 12, 1, 22 },
                    { 19, 1, 1, 2, 23 },
                    { 38, 1, 2, 3, 23 },
                    { 294, 2, 4, 4, 21 },
                    { 793, 7, 7, 3, 13 },
                    { 774, 7, 6, 4, 13 },
                    { 755, 7, 5, 3, 13 },
                    { 194, 1, 11, 1, 5 },
                    { 213, 1, 12, 1, 5 },
                    { 233, 2, 1, 3, 5 },
                    { 251, 2, 2, 3, 5 },
                    { 269, 2, 3, 2, 5 },
                    { 287, 2, 4, 2, 5 },
                    { 305, 2, 5, 1, 5 },
                    { 323, 2, 6, 1, 5 },
                    { 341, 2, 7, 1, 5 },
                    { 359, 2, 8, 3, 5 },
                    { 377, 2, 9, 4, 5 },
                    { 175, 1, 10, 1, 5 },
                    { 395, 2, 10, 4, 5 },
                    { 431, 2, 12, 4, 5 },
                    { 676, 7, 1, 4, 5 },
                    { 695, 7, 2, 4, 5 },
                    { 714, 7, 3, 4, 5 },
                    { 733, 7, 4, 4, 5 },
                    { 752, 7, 5, 3, 5 },
                    { 771, 7, 6, 2, 5 },
                    { 790, 7, 7, 2, 5 },
                    { 809, 7, 8, 1, 5 },
                    { 828, 7, 9, 1, 5 },
                    { 847, 7, 10, 2, 5 },
                    { 413, 2, 11, 4, 5 },
                    { 866, 7, 11, 3, 5 },
                    { 156, 1, 9, 1, 5 },
                    { 118, 1, 7, 3, 5 },
                    { 117, 1, 7, 3, 4 },
                    { 136, 1, 8, 2, 4 },
                    { 155, 1, 9, 1, 4 },
                    { 174, 1, 10, 2, 4 },
                    { 193, 1, 11, 2, 4 },
                    { 212, 1, 12, 2, 4 },
                    { 447, 3, 1, 4, 4 },
                    { 463, 3, 2, 4, 4 },
                    { 479, 3, 3, 4, 4 },
                    { 495, 3, 4, 4, 4 },
                    { 511, 3, 5, 2, 4 },
                    { 137, 1, 8, 2, 5 },
                    { 527, 3, 6, 1, 4 },
                    { 559, 3, 8, 1, 4 },
                    { 575, 3, 9, 1, 4 },
                    { 591, 3, 10, 2, 4 },
                    { 607, 3, 11, 2, 4 },
                    { 623, 3, 12, 3, 4 },
                    { 4, 1, 1, 2, 5 },
                    { 23, 1, 2, 3, 5 },
                    { 42, 1, 3, 3, 5 },
                    { 61, 1, 4, 4, 5 },
                    { 80, 1, 5, 4, 5 },
                    { 99, 1, 6, 4, 5 },
                    { 543, 3, 7, 1, 4 },
                    { 98, 1, 6, 4, 4 },
                    { 885, 7, 12, 4, 5 },
                    { 24, 1, 2, 3, 6 },
                    { 342, 2, 7, 1, 7 },
                    { 360, 2, 8, 1, 7 },
                    { 378, 2, 9, 2, 7 },
                    { 396, 2, 10, 3, 7 },
                    { 414, 2, 11, 4, 7 },
                    { 432, 2, 12, 4, 7 },
                    { 677, 7, 1, 4, 7 },
                    { 696, 7, 2, 4, 7 },
                    { 715, 7, 3, 4, 7 },
                    { 734, 7, 4, 3, 7 },
                    { 753, 7, 5, 2, 7 },
                    { 324, 2, 6, 1, 7 },
                    { 772, 7, 6, 1, 7 },
                    { 810, 7, 8, 1, 7 },
                    { 829, 7, 9, 1, 7 },
                    { 848, 7, 10, 2, 7 },
                    { 867, 7, 11, 3, 7 },
                    { 886, 7, 12, 4, 7 },
                    { 6, 1, 1, 3, 8 },
                    { 25, 1, 2, 2, 8 },
                    { 44, 1, 3, 2, 8 },
                    { 63, 1, 4, 3, 8 },
                    { 82, 1, 5, 4, 8 },
                    { 101, 1, 6, 4, 8 },
                    { 791, 7, 7, 1, 7 },
                    { 5, 1, 1, 3, 6 },
                    { 306, 2, 5, 1, 7 },
                    { 270, 2, 3, 2, 7 },
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
                    { 448, 3, 1, 1, 6 },
                    { 288, 2, 4, 1, 7 },
                    { 464, 3, 2, 1, 6 },
                    { 496, 3, 4, 2, 6 },
                    { 512, 3, 5, 3, 6 },
                    { 528, 3, 6, 3, 6 },
                    { 544, 3, 7, 3, 6 },
                    { 560, 3, 8, 3, 6 },
                    { 576, 3, 9, 3, 6 },
                    { 592, 3, 10, 3, 6 },
                    { 608, 3, 11, 1, 6 },
                    { 624, 3, 12, 1, 6 },
                    { 234, 2, 1, 4, 7 },
                    { 252, 2, 2, 3, 7 },
                    { 480, 3, 3, 2, 6 },
                    { 79, 1, 5, 4, 4 },
                    { 60, 1, 4, 3, 4 },
                    { 41, 1, 3, 2, 4 },
                    { 525, 3, 6, 1, 1 },
                    { 541, 3, 7, 1, 1 },
                    { 557, 3, 8, 1, 1 },
                    { 573, 3, 9, 1, 1 },
                    { 589, 3, 10, 1, 1 },
                    { 605, 3, 11, 1, 1 },
                    { 621, 3, 12, 2, 1 },
                    { 673, 7, 1, 2, 1 },
                    { 692, 7, 2, 3, 1 },
                    { 711, 7, 3, 4, 1 },
                    { 730, 7, 4, 4, 1 },
                    { 509, 3, 5, 2, 1 },
                    { 749, 7, 5, 4, 1 },
                    { 787, 7, 7, 4, 1 },
                    { 806, 7, 8, 4, 1 },
                    { 825, 7, 9, 4, 1 },
                    { 844, 7, 10, 3, 1 },
                    { 863, 7, 11, 2, 1 },
                    { 882, 7, 12, 1, 1 },
                    { 230, 2, 1, 4, 2 },
                    { 248, 2, 2, 4, 2 },
                    { 266, 2, 3, 4, 2 },
                    { 284, 2, 4, 4, 2 },
                    { 302, 2, 5, 4, 2 },
                    { 768, 7, 6, 4, 1 },
                    { 320, 2, 6, 4, 2 },
                    { 493, 3, 4, 2, 1 },
                    { 461, 3, 2, 2, 1 },
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
                    { 477, 3, 3, 2, 1 },
                    { 229, 2, 1, 3, 1 },
                    { 265, 2, 3, 2, 1 },
                    { 283, 2, 4, 1, 1 },
                    { 301, 2, 5, 1, 1 },
                    { 319, 2, 6, 1, 1 },
                    { 337, 2, 7, 1, 1 },
                    { 355, 2, 8, 1, 1 },
                    { 373, 2, 9, 4, 1 },
                    { 391, 2, 10, 4, 1 },
                    { 409, 2, 11, 4, 1 },
                    { 427, 2, 12, 4, 1 },
                    { 445, 3, 1, 2, 1 },
                    { 247, 2, 2, 3, 1 },
                    { 338, 2, 7, 4, 2 },
                    { 356, 2, 8, 4, 2 },
                    { 374, 2, 9, 4, 2 },
                    { 268, 2, 3, 3, 3 },
                    { 286, 2, 4, 4, 3 },
                    { 304, 2, 5, 4, 3 },
                    { 322, 2, 6, 4, 3 },
                    { 340, 2, 7, 4, 3 },
                    { 358, 2, 8, 4, 3 },
                    { 376, 2, 9, 4, 3 },
                    { 394, 2, 10, 3, 3 },
                    { 412, 2, 11, 2, 3 },
                    { 430, 2, 12, 2, 3 },
                    { 446, 3, 1, 2, 3 },
                    { 250, 2, 2, 2, 3 },
                    { 462, 3, 2, 2, 3 },
                    { 494, 3, 4, 3, 3 },
                    { 510, 3, 5, 3, 3 },
                    { 526, 3, 6, 3, 3 },
                    { 542, 3, 7, 1, 3 },
                    { 558, 3, 8, 1, 3 },
                    { 574, 3, 9, 3, 3 },
                    { 590, 3, 10, 3, 3 },
                    { 606, 3, 11, 1, 3 },
                    { 622, 3, 12, 1, 3 },
                    { 3, 1, 1, 1, 4 },
                    { 22, 1, 2, 2, 4 },
                    { 478, 3, 3, 2, 3 },
                    { 232, 2, 1, 2, 3 },
                    { 211, 1, 12, 3, 3 },
                    { 192, 1, 11, 3, 3 },
                    { 392, 2, 10, 4, 2 },
                    { 410, 2, 11, 4, 2 },
                    { 428, 2, 12, 4, 2 },
                    { 674, 7, 1, 1, 2 },
                    { 693, 7, 2, 2, 2 },
                    { 712, 7, 3, 3, 2 },
                    { 731, 7, 4, 4, 2 },
                    { 750, 7, 5, 4, 2 },
                    { 769, 7, 6, 2, 2 },
                    { 788, 7, 7, 4, 2 },
                    { 807, 7, 8, 4, 2 },
                    { 826, 7, 9, 3, 2 },
                    { 845, 7, 10, 3, 2 },
                    { 864, 7, 11, 2, 2 },
                    { 883, 7, 12, 1, 2 },
                    { 2, 1, 1, 3, 3 },
                    { 21, 1, 2, 3, 3 },
                    { 40, 1, 3, 3, 3 },
                    { 59, 1, 4, 3, 3 },
                    { 78, 1, 5, 3, 3 },
                    { 97, 1, 6, 3, 3 },
                    { 116, 1, 7, 3, 3 },
                    { 135, 1, 8, 3, 3 },
                    { 154, 1, 9, 3, 3 },
                    { 173, 1, 10, 3, 3 },
                    { 120, 1, 7, 4, 8 },
                    { 139, 1, 8, 3, 8 },
                    { 158, 1, 9, 1, 8 },
                    { 177, 1, 10, 1, 8 },
                    { 644, 4, 8, 1, 11 },
                    { 645, 4, 9, 1, 11 },
                    { 646, 4, 10, 1, 11 },
                    { 647, 4, 11, 1, 11 },
                    { 648, 4, 12, 1, 11 },
                    { 649, 5, 1, 1, 11 },
                    { 650, 5, 2, 1, 11 },
                    { 651, 5, 3, 1, 11 },
                    { 652, 5, 4, 4, 11 },
                    { 653, 5, 5, 1, 11 },
                    { 654, 5, 6, 1, 11 },
                    { 643, 4, 7, 1, 11 },
                    { 655, 5, 7, 1, 11 },
                    { 657, 5, 9, 1, 11 },
                    { 658, 5, 10, 1, 11 },
                    { 659, 5, 11, 1, 11 },
                    { 660, 5, 12, 1, 11 },
                    { 661, 6, 1, 1, 11 },
                    { 662, 6, 2, 1, 11 },
                    { 663, 6, 3, 1, 11 },
                    { 664, 6, 4, 4, 11 },
                    { 665, 6, 5, 1, 11 },
                    { 666, 6, 6, 1, 11 },
                    { 667, 6, 7, 1, 11 },
                    { 656, 5, 8, 1, 11 },
                    { 668, 6, 8, 1, 11 },
                    { 642, 4, 6, 1, 11 },
                    { 640, 4, 4, 4, 11 },
                    { 285, 2, 4, 3, 11 },
                    { 303, 2, 5, 4, 11 },
                    { 321, 2, 6, 4, 11 },
                    { 339, 2, 7, 4, 11 },
                    { 357, 2, 8, 4, 11 },
                    { 375, 2, 9, 2, 11 },
                    { 393, 2, 10, 1, 11 },
                    { 411, 2, 11, 1, 11 },
                    { 429, 2, 12, 1, 11 },
                    { 452, 3, 1, 1, 11 },
                    { 468, 3, 2, 1, 11 },
                    { 641, 4, 5, 1, 11 },
                    { 484, 3, 3, 1, 11 },
                    { 516, 3, 5, 1, 11 },
                    { 532, 3, 6, 1, 11 },
                    { 548, 3, 7, 2, 11 },
                    { 564, 3, 8, 3, 11 },
                    { 580, 3, 9, 4, 11 },
                    { 596, 3, 10, 4, 11 },
                    { 612, 3, 11, 1, 11 },
                    { 628, 3, 12, 1, 11 },
                    { 637, 4, 1, 1, 11 },
                    { 638, 4, 2, 1, 11 },
                    { 639, 4, 3, 1, 11 },
                    { 500, 3, 4, 1, 11 },
                    { 669, 6, 9, 1, 11 },
                    { 670, 6, 10, 1, 11 },
                    { 671, 6, 11, 1, 11 },
                    { 517, 3, 5, 1, 12 },
                    { 533, 3, 6, 3, 12 },
                    { 549, 3, 7, 3, 12 },
                    { 565, 3, 8, 4, 12 },
                    { 581, 3, 9, 4, 12 },
                    { 597, 3, 10, 3, 12 },
                    { 613, 3, 11, 1, 12 },
                    { 629, 3, 12, 1, 12 },
                    { 242, 2, 1, 1, 13 },
                    { 260, 2, 2, 2, 13 },
                    { 278, 2, 3, 3, 13 },
                    { 501, 3, 4, 1, 12 },
                    { 296, 2, 4, 4, 13 },
                    { 332, 2, 6, 4, 13 },
                    { 350, 2, 7, 3, 13 },
                    { 368, 2, 8, 2, 13 },
                    { 386, 2, 9, 2, 13 },
                    { 404, 2, 10, 1, 13 },
                    { 422, 2, 11, 1, 13 },
                    { 440, 2, 12, 1, 13 },
                    { 679, 7, 1, 1, 13 },
                    { 698, 7, 2, 1, 13 },
                    { 717, 7, 3, 1, 13 },
                    { 736, 7, 4, 1, 13 },
                    { 314, 2, 5, 4, 13 },
                    { 485, 3, 3, 1, 12 },
                    { 469, 3, 2, 1, 12 },
                    { 453, 3, 1, 1, 12 },
                    { 672, 6, 12, 1, 11 },
                    { 675, 7, 1, 1, 11 },
                    { 694, 7, 2, 2, 11 },
                    { 713, 7, 3, 3, 11 },
                    { 732, 7, 4, 4, 11 },
                    { 751, 7, 5, 4, 11 },
                    { 770, 7, 6, 4, 11 },
                    { 789, 7, 7, 3, 11 },
                    { 808, 7, 8, 3, 11 },
                    { 827, 7, 9, 2, 11 },
                    { 846, 7, 10, 1, 11 },
                    { 865, 7, 11, 1, 11 },
                    { 884, 7, 12, 1, 11 },
                    { 10, 1, 1, 4, 12 },
                    { 29, 1, 2, 4, 12 },
                    { 48, 1, 3, 4, 12 },
                    { 67, 1, 4, 4, 12 },
                    { 86, 1, 5, 4, 12 },
                    { 105, 1, 6, 4, 12 },
                    { 124, 1, 7, 4, 12 },
                    { 143, 1, 8, 3, 12 },
                    { 162, 1, 9, 3, 12 },
                    { 181, 1, 10, 3, 12 },
                    { 200, 1, 11, 3, 12 },
                    { 219, 1, 12, 3, 12 },
                    { 267, 2, 3, 2, 11 },
                    { 881, 7, 11, 1, 30 },
                    { 249, 2, 2, 2, 11 },
                    { 218, 1, 12, 3, 11 },
                    { 45, 1, 3, 1, 9 },
                    { 64, 1, 4, 2, 9 },
                    { 83, 1, 5, 2, 9 },
                    { 102, 1, 6, 3, 9 },
                    { 121, 1, 7, 4, 9 },
                    { 140, 1, 8, 4, 9 },
                    { 159, 1, 9, 4, 9 },
                    { 178, 1, 10, 4, 9 },
                    { 197, 1, 11, 4, 9 },
                    { 216, 1, 12, 3, 9 },
                    { 236, 2, 1, 1, 9 },
                    { 26, 1, 2, 2, 9 },
                    { 254, 2, 2, 2, 9 },
                    { 290, 2, 4, 4, 9 },
                    { 308, 2, 5, 4, 9 },
                    { 326, 2, 6, 4, 9 },
                    { 344, 2, 7, 4, 9 },
                    { 362, 2, 8, 3, 9 },
                    { 380, 2, 9, 2, 9 },
                    { 398, 2, 10, 1, 9 },
                    { 416, 2, 11, 1, 9 },
                    { 434, 2, 12, 1, 9 },
                    { 450, 3, 1, 1, 9 },
                    { 466, 3, 2, 1, 9 },
                    { 272, 2, 3, 3, 9 },
                    { 482, 3, 3, 1, 9 },
                    { 7, 1, 1, 3, 9 },
                    { 609, 3, 11, 2, 8 },
                    { 196, 1, 11, 2, 8 },
                    { 215, 1, 12, 3, 8 },
                    { 235, 2, 1, 4, 8 },
                    { 253, 2, 2, 4, 8 },
                    { 271, 2, 3, 2, 8 },
                    { 289, 2, 4, 1, 8 },
                    { 307, 2, 5, 1, 8 },
                    { 325, 2, 6, 1, 8 },
                    { 343, 2, 7, 1, 8 },
                    { 361, 2, 8, 1, 8 },
                    { 379, 2, 9, 1, 8 },
                    { 625, 3, 12, 4, 8 },
                    { 397, 2, 10, 3, 8 },
                    { 433, 2, 12, 4, 8 },
                    { 449, 3, 1, 4, 8 },
                    { 465, 3, 2, 4, 8 },
                    { 481, 3, 3, 4, 8 },
                    { 497, 3, 4, 3, 8 },
                    { 513, 3, 5, 1, 8 },
                    { 529, 3, 6, 1, 8 },
                    { 545, 3, 7, 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "DestSpeciesMonth",
                columns: new[] { "DestSpeciesMonthId", "DSMDestinationId", "DSMMonthId", "DSMRatingId", "DSMSpeciesId" },
                values: new object[,]
                {
                    { 561, 3, 8, 1, 8 },
                    { 577, 3, 9, 1, 8 },
                    { 593, 3, 10, 1, 8 },
                    { 415, 2, 11, 4, 8 },
                    { 498, 3, 4, 1, 9 },
                    { 514, 3, 5, 2, 9 },
                    { 530, 3, 6, 3, 9 },
                    { 217, 1, 12, 3, 10 },
                    { 451, 3, 1, 1, 10 },
                    { 467, 3, 2, 1, 10 },
                    { 483, 3, 3, 1, 10 },
                    { 499, 3, 4, 1, 10 },
                    { 515, 3, 5, 1, 10 },
                    { 531, 3, 6, 1, 10 },
                    { 547, 3, 7, 2, 10 },
                    { 563, 3, 8, 3, 10 },
                    { 579, 3, 9, 4, 10 },
                    { 595, 3, 10, 4, 10 },
                    { 198, 1, 11, 3, 10 },
                    { 611, 3, 11, 1, 10 },
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
                    { 627, 3, 12, 1, 10 },
                    { 179, 1, 10, 3, 10 },
                    { 160, 1, 9, 3, 10 },
                    { 141, 1, 8, 3, 10 },
                    { 546, 3, 7, 4, 9 },
                    { 562, 3, 8, 4, 9 },
                    { 578, 3, 9, 3, 9 },
                    { 594, 3, 10, 3, 9 },
                    { 610, 3, 11, 1, 9 },
                    { 626, 3, 12, 1, 9 },
                    { 678, 7, 1, 4, 9 },
                    { 697, 7, 2, 2, 9 },
                    { 716, 7, 3, 1, 9 },
                    { 735, 7, 4, 2, 9 },
                    { 754, 7, 5, 3, 9 },
                    { 773, 7, 6, 4, 9 },
                    { 792, 7, 7, 4, 9 },
                    { 811, 7, 8, 4, 9 },
                    { 830, 7, 9, 4, 9 },
                    { 849, 7, 10, 3, 9 },
                    { 868, 7, 11, 2, 9 },
                    { 887, 7, 12, 1, 9 },
                    { 8, 1, 1, 2, 10 },
                    { 27, 1, 2, 2, 10 },
                    { 46, 1, 3, 1, 10 },
                    { 65, 1, 4, 1, 10 },
                    { 84, 1, 5, 1, 10 },
                    { 103, 1, 6, 2, 10 },
                    { 122, 1, 7, 3, 10 },
                    { 231, 2, 1, 1, 11 },
                    { 900, 7, 12, 1, 30 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoTripId",
                table: "Photos",
                column: "PhotoTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DestinationId",
                table: "Trip",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_ExplorerId",
                table: "Trip",
                column: "ExplorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripMonthId",
                table: "Trip",
                column: "TripMonthId");
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
                name: "Photos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Explorer");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
