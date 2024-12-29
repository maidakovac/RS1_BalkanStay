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
                name: "Administrators",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorID);
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
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MyAppUsers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAppUsers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_MyAppUsers_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MyAppUsers_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyAppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_MyAppUsers_MyAppUserID",
                        column: x => x.MyAppUserID,
                        principalTable: "MyAppUsers",
                        principalColumn: "UserID");
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
                    MyAppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAuthenticationTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyAuthenticationTokens_MyAppUsers_MyAppUserId",
                        column: x => x.MyAppUserId,
                        principalTable: "MyAppUsers",
                        principalColumn: "UserID");
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
                        name: "FK_TwoFactorAuths_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                column: "AdministratorID",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Example Country1" },
                    { 2, "Example Country2" },
                    { 3, "Example Country3" },
                    { 4, "Example Country4" }
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
                table: "Cities",
                columns: new[] { "ID", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Example City" },
                    { 2, 1, "Another City" },
                    { 3, 1, "Third City" },
                    { 4, 1, "Four City" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ApartmentId", "Adress", "CityId", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, "Adresa 1", 1, "opis neki", "Apartment Marshal", 50 },
                    { 2, "Adresa 2", 2, "opis neki", "Apartment Charm", 70 },
                    { 3, "Adresa 3", 3, "opis neki", "Apartment Sun", 50 },
                    { 4, "Adresa 4", 4, "opis neki", "Apartment Exclusive", 150 }
                });

            migrationBuilder.InsertData(
                table: "MyAppUsers",
                columns: new[] { "UserID", "CityID", "Email", "GenderID", "Image", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "manager1@example.com", null, new byte[0], "123-456-7891" },
                    { 2, 2, "manager1@example.com", null, new byte[0], "123-456-7891" },
                    { 3, 3, "manager1@example.com", null, new byte[0], "123-456-6666" },
                    { 4, 4, "manager1@example.com", null, new byte[0], "123-456-8888" },
                    { 5, 1, "manager5@example.com", null, new byte[0], "123-456-7777" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountID", "FirstName", "LastName", "MyAppUserID", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "izel", "repuh", 1, "xxxx", "izellapin" },
                    { 2, "maida", "kovac", 2, "yyyy", "maidakcv" },
                    { 3, "user", "userlastname", 3, "zzzz**", "usernameexample" },
                    { 4, "example", "examplelastname", 4, "hhhh", "example" },
                    { 5, "exampleXX", "examplelastnameXXX", 5, "ggggXX", "examplexxx" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MyAppUserID",
                table: "Accounts",
                column: "MyAppUserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_CityId",
                table: "Apartments",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MyAppUsers_CityID",
                table: "MyAppUsers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_MyAppUsers_GenderID",
                table: "MyAppUsers",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_MyAuthenticationTokens_MyAppUserId",
                table: "MyAuthenticationTokens",
                column: "MyAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorAuths_AccountId",
                table: "TwoFactorAuths",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "MyAuthenticationTokens");

            migrationBuilder.DropTable(
                name: "TwoFactorAuths");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "MyAppUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
