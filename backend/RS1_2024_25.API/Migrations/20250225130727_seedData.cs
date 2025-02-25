using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "Description",
                value: "A stylish and modern apartment in a prime location, perfect for travelers.");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "Description",
                value: "A cozy and charming space with elegant decor and a warm atmosphere.");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "Description",
                value: "Bright and spacious apartment with plenty of natural light and a stunning view.");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "Description",
                value: "A luxury apartment with high-end amenities, ideal for a premium experience.");

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ApartmentId", "AccountID", "Adress", "CityId", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 5, null, "Bjelašnica 12", 6, "A cozy retreat with a breathtaking mountain view.", "Mountain View Lodge", 80 },
                    { 6, null, "Obala 45, Rijeka", 7, "A luxurious apartment right by the Adriatic Sea.", "Seaside Escape", 120 },
                    { 7, null, "Centar 22, Novi Sad", 8, "Modern loft in the heart of the city, perfect for business travelers.", "Urban Loft", 95 },
                    { 8, null, "Stari Grad 17, Skopje", 10, "Stay in a beautifully restored historic building in the old town.", "Historic Downtown Apartment", 70 },
                    { 9, null, "Skyline Tower, Athens", 19, "Exclusive penthouse with a private terrace and panoramic city views.", "Luxury Penthouse", 250 }
                });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 7, 27, 175, DateTimeKind.Utc).AddTicks(1600));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "Description",
                value: "opis neki");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "Description",
                value: "opis neki");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "Description",
                value: "opis neki");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "Description",
                value: "opis neki");

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 0, 13, 691, DateTimeKind.Utc).AddTicks(4898));
        }
    }
}
