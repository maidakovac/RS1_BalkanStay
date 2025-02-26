using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleID);
                });

            migrationBuilder.CreateTable(
                name: "Toiletries",
                columns: table => new
                {
                    ToiletryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toiletries", x => x.ToiletryID);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Administrator_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyAuthenticationTokens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAuthenticationTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyAuthenticationTokens_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "TwoFactorAuths",
                columns: table => new
                {
                    TwoFactorAuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AuthToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFactorAuths", x => x.TwoFactorAuthId);
                    table.ForeignKey(
                        name: "FK_TwoFactorAuths_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Owner_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owner_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Owner_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_User_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_User_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID");
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    AccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Apartments_Owner_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Owner",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "OwnerReviews",
                columns: table => new
                {
                    OwnerReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerReviews", x => x.OwnerReviewID);
                    table.ForeignKey(
                        name: "FK_OwnerReviews_Owner_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owner",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_OwnerReviews_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentAmenities",
                columns: table => new
                {
                    ApartmentAmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentAmenities", x => x.ApartmentAmenityID);
                    table.ForeignKey(
                        name: "FK_ApartmentAmenities_Amenities_AmenityID",
                        column: x => x.AmenityID,
                        principalTable: "Amenities",
                        principalColumn: "AmenityID");
                    table.ForeignKey(
                        name: "FK_ApartmentAmenities_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentImages",
                columns: table => new
                {
                    ApartmentImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentImages", x => x.ApartmentImageID);
                    table.ForeignKey(
                        name: "FK_ApartmentImages_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_ApartmentImages_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentRules",
                columns: table => new
                {
                    ApartmentRuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    RuleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentRules", x => x.ApartmentRuleID);
                    table.ForeignKey(
                        name: "FK_ApartmentRules_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_ApartmentRules_Rules_RuleID",
                        column: x => x.RuleID,
                        principalTable: "Rules",
                        principalColumn: "RuleID");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentToiletries",
                columns: table => new
                {
                    ApartmentToiletryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ToiletryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentToiletries", x => x.ApartmentToiletryID);
                    table.ForeignKey(
                        name: "FK_ApartmentToiletries_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_ApartmentToiletries_Toiletries_ToiletryID",
                        column: x => x.ToiletryID,
                        principalTable: "Toiletries",
                        principalColumn: "ToiletryID");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    UserAccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteID);
                    table.ForeignKey(
                        name: "FK_Favorites_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Favorites_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_Favorites_User_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "User",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserAccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Reservations_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_Reservations_User_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "User",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Reviews_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId");
                    table.ForeignKey(
                        name: "FK_Reviews_User_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "User",
                        principalColumn: "AccountID");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountID", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "User", "AdminPass", "admin" },
                    { 2, "superadmin@example.com", "Super", "Admin", "SuperPass", "superadmin" },
                    { 3, "izelrepuh@example.com", "Izel", "Repuh", "SuperPass", "izelrepuh" },
                    { 4, "amaromer@example.com", "Amar", "Omer", "SuperAmar", "amaromer" },
                    { 5, "johndoe@example.com", "John", "Doe", "JohnPass", "johndoe" },
                    { 6, "janedoe@example.com", "Jane", "Doe", "JanePass", "janedoe" },
                    { 7, "xxxx@example.com", "Xkorisnik", "PKorisnik", "xxxxx", "xxxxx" },
                    { 8, "yyyy@example.com", "YYKorisnik", "YYPrezime", "YYYXX", "yyyy" },
                    { 9, "izel@gmail.com", "Izel", "Repuh", "Izel", "Izel" },
                    { 10, "maida@gmail.com", "Maida", "Kovac", "Maida", "Maida" },
                    { 11, "owner@gmail.com", "Admin", "Admin", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityID", "AmenityText" },
                values: new object[,]
                {
                    { 1, "Besplatan parking" },
                    { 2, "Klima uređaj" },
                    { 3, "Veš mašina" },
                    { 4, "Pogled s terase" },
                    { 5, "Bazen" },
                    { 6, "Sauna" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Bosna i Hercegovina" },
                    { 2, "Hrvatska" },
                    { 3, "Srbija" },
                    { 4, "Makedonija" },
                    { 5, "Bugarska" },
                    { 6, "Crna Gora" },
                    { 7, "Albanija" },
                    { 8, "Grčka" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderID", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ImagePath" },
                values: new object[,]
                {
                    { 1, "wwwroot/images/image2.jpg" },
                    { 2, "wwwroot/images/room1.jpg" },
                    { 3, "wwwroot/images/toilet2.jpg" },
                    { 4, "wwwroot/images/room1.jpg" },
                    { 5, "wwwroot/images/image2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "RuleID", "RuleText" },
                values: new object[,]
                {
                    { 1, "Zabranjeno pusenje" },
                    { 2, "Zabranjene zabave" },
                    { 3, "Dozvoljeni ljubimci" },
                    { 4, "Zabranjeno prekoracenje kapaciteta osoba" },
                    { 5, "Zabranjeno NESTO" }
                });

            migrationBuilder.InsertData(
                table: "Toiletries",
                columns: new[] { "ToiletryID", "Name" },
                values: new object[,]
                {
                    { 1, "Sapun" },
                    { 2, "Šampon" },
                    { 3, "Regenerator" },
                    { 4, "Fen" },
                    { 5, "Peškiri" }
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "AccountID", "Image" },
                values: new object[,]
                {
                    { 1, null },
                    { 2, null },
                    { 3, null },
                    { 4, null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sarajevo" },
                    { 2, 1, "Mostar" },
                    { 3, 1, "Tuzla" },
                    { 4, 2, "Zagreb" },
                    { 5, 2, "Rijeka" },
                    { 6, 2, "Pula" },
                    { 7, 3, "Beograd" },
                    { 8, 3, "Novi Sad" },
                    { 9, 4, "Skopje" },
                    { 10, 4, "Ohrid" },
                    { 11, 5, "Sofia" },
                    { 12, 5, "Varna" },
                    { 13, 6, "Budva" },
                    { 14, 6, "Bar" },
                    { 15, 6, "Kotor" },
                    { 16, 7, "Tirana" },
                    { 17, 7, "Vlorë" },
                    { 18, 7, "Durrës" },
                    { 19, 8, "Atena" },
                    { 20, 8, "Thessaloniki" },
                    { 21, 8, "Patras" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ApartmentId", "AccountID", "Adress", "CityId", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, null, "Adresa 1", 1, "A stylish and modern apartment in a prime location, perfect for travelers.", "Apartment Marshal", 50 },
                    { 2, null, "Adresa 2", 2, "A cozy and charming space with elegant decor and a warm atmosphere.", "Apartment Charm", 70 },
                    { 3, null, "Adresa 3", 3, "Bright and spacious apartment with plenty of natural light and a stunning view.", "Apartment Sun", 50 },
                    { 4, null, "Adresa 4", 4, "A luxury apartment with high-end amenities, ideal for a premium experience.", "Apartment Exclusive", 150 },
                    { 5, null, "Bjelašnica 12", 6, "A cozy retreat with a breathtaking mountain view.", "Mountain View Lodge", 80 },
                    { 6, null, "Obala 45, Rijeka", 7, "A luxurious apartment right by the Adriatic Sea.", "Seaside Escape", 120 },
                    { 7, null, "Centar 22, Novi Sad", 8, "Modern loft in the heart of the city, perfect for business travelers.", "Urban Loft", 95 },
                    { 8, null, "Stari Grad 17, Skopje", 10, "Stay in a beautifully restored historic building in the old town.", "Historic Downtown Apartment", 70 },
                    { 9, null, "Skyline Tower, Athens", 19, "Exclusive penthouse with a private terrace and panoramic city views.", "Luxury Penthouse", 250 }
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "AccountID", "CityID", "CreatedAt", "GenderID", "Image", "Phone" },
                values: new object[,]
                {
                    { 9, 1, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(7161), 2, new byte[0], "061-000-111" },
                    { 10, 2, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(7333), 2, new byte[0], "061-000-222" },
                    { 11, 3, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(7336), 1, new byte[0], "061-000-333" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "AccountID", "CityID", "CreatedAt", "GenderID", "Image", "Phone" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(6242), 1, null, "+38761000111" },
                    { 6, 2, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(6420), 2, null, "+38761000222" },
                    { 7, 3, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(6422), 1, null, "+38761000222" },
                    { 8, 4, new DateTime(2025, 2, 26, 11, 53, 23, 854, DateTimeKind.Utc).AddTicks(6423), 2, null, "+38761000222" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentAmenities",
                columns: new[] { "ApartmentAmenityID", "AmenityID", "ApartmentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ApartmentImages",
                columns: new[] { "ApartmentImageID", "ApartmentId", "ImageID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 1 },
                    { 7, 7, 2 },
                    { 8, 8, 3 },
                    { 9, 9, 4 }
                });

            migrationBuilder.InsertData(
                table: "ApartmentRules",
                columns: new[] { "ApartmentRuleID", "ApartmentId", "RuleID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 1, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "ApartmentToiletries",
                columns: new[] { "ApartmentToiletryID", "ApartmentId", "ToiletryID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAmenities_AmenityID",
                table: "ApartmentAmenities",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentAmenities_ApartmentId",
                table: "ApartmentAmenities",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentImages_ApartmentId",
                table: "ApartmentImages",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentImages_ImageID",
                table: "ApartmentImages",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentRules_ApartmentId",
                table: "ApartmentRules",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentRules_RuleID",
                table: "ApartmentRules",
                column: "RuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AccountID",
                table: "Apartments",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CityId",
                table: "Apartments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentToiletries_ApartmentId",
                table: "ApartmentToiletries",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentToiletries_ToiletryID",
                table: "ApartmentToiletries",
                column: "ToiletryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AccountID",
                table: "Favorites",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ApartmentId",
                table: "Favorites",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserAccountID",
                table: "Favorites",
                column: "UserAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_MyAuthenticationTokens_AccountId",
                table: "MyAuthenticationTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_CityID",
                table: "Owner",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_GenderID",
                table: "Owner",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerReviews_OwnerID",
                table: "OwnerReviews",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerReviews_UserID",
                table: "OwnerReviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccountID",
                table: "Reservations",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApartmentId",
                table: "Reservations",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserAccountID",
                table: "Reservations",
                column: "UserAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AccountID",
                table: "Reviews",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserAccountID",
                table: "Reviews",
                column: "UserAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorAuths_AccountId",
                table: "TwoFactorAuths",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CityID",
                table: "User",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderID",
                table: "User",
                column: "GenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "ApartmentAmenities");

            migrationBuilder.DropTable(
                name: "ApartmentImages");

            migrationBuilder.DropTable(
                name: "ApartmentRules");

            migrationBuilder.DropTable(
                name: "ApartmentToiletries");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "MyAuthenticationTokens");

            migrationBuilder.DropTable(
                name: "OwnerReviews");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TwoFactorAuths");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Toiletries");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
