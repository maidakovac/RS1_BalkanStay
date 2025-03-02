using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class apartmentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ApartmentId", "AccountID", "Adress", "CityId", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 31, null, "Keј Marshal Tito 11, Ohrid", 10, "Stunning views of Lake Ohrid.", "Ohrid Lake View", 80 },
                    { 32, null, "Car Samoil Street 5, Ohrid", 10, "Charming apartment in Ohrid's historic center.", "Old Town Retreat", 70 },
                    { 33, null, "Macedonia Street 15, Ohrid", 10, "High-end suite with a private balcony and lake view.", "Luxury Lakeside Suite", 120 },
                    { 34, null, "Vitosha Blvd 15, Sofia", 11, "Penthouse apartment in the heart of Sofia.", "Sofia Panorama", 110 },
                    { 35, null, "Aleksandar Stamboliyski Blvd 22, Sofia", 11, "Modern loft in downtown Sofia.", "Sofia Central Loft", 95 },
                    { 36, null, "Tsarigradsko Shose 30, Sofia", 11, "Premium business-class apartment.", "Luxury Business Suite", 130 },
                    { 37, null, "Golden Sands 5, Varna", 12, "Beachfront apartment in Varna.", "Varna Sea View", 100 },
                    { 38, null, "Slivnitsa Blvd 8, Varna", 12, "Luxury retreat near Varna Beach.", "Coastal Paradise", 110 },
                    { 39, null, "Opalchenska Street 12, Varna", 12, "Cozy apartment near Varna Cathedral.", "Historic Varna Stay", 90 },
                    { 40, null, "Slovenska Plaža 3, Budva", 13, "Luxury stay near the Budva beaches.", "Budva Riviera", 120 },
                    { 41, null, "Mediteranska Street 7, Budva", 13, "Charming stone-built apartment in Old Town.", "Budva Old Town Escape", 100 },
                    { 42, null, "Jadranski Put 15, Budva", 13, "Relaxing stay near the famous Mogren Beach.", "Seaside Comfort Apartment", 110 },
                    { 43, null, "Marina Street 10, Bar", 14, "Modern apartment overlooking the Adriatic Sea.", "Bar Harbor View", 95 },
                    { 44, null, "King Nikola Street 5, Bar", 14, "Rustic apartment in Bar's historical quarter.", "Old Town Charm", 85 },
                    { 45, null, "Bar Beach Avenue 2, Bar", 14, "Exclusive suite right on the beach.", "Luxury Beachfront Suite", 125 },
                    { 46, null, "Kotor Bay Road 10, Kotor", 15, "Enjoy breathtaking bay views from this stunning apartment.", "Bay of Kotor Retreat", 115 },
                    { 47, null, "Stari Grad 8, Kotor", 15, "Charming stay in a UNESCO-protected area.", "Historic Kotor Stay", 105 },
                    { 48, null, "Porto Montenegro 3, Kotor", 15, "Exclusive stay next to Kotor’s yacht marina.", "Luxury Yacht Marina Apartment", 140 },
                    { 49, null, "Blloku District 6, Tirana", 16, "Modern loft in downtown Tirana.", "Tirana Central Loft", 90 },
                    { 50, null, "Sheshi Skënderbej 10, Tirana", 16, "Exclusive penthouse overlooking Skanderbeg Square.", "Luxury Skanderbeg Suite", 130 },
                    { 51, null, "Rruga Kavajes 15, Tirana", 16, "A chic and comfortable apartment in the heart of Tirana.", "Stylish Urban Retreat", 100 },
                    { 52, null, "Rruga Dhimiter Konomi 8, Vlorë", 17, "Beautiful beachfront apartment.", "Vlorë Beachfront Getaway", 110 },
                    { 53, null, "Lungomare Boulevard 3, Vlorë", 17, "High-end stay with panoramic sea views.", "Luxury Seaside Escape", 130 },
                    { 54, null, "Sheshi Flamurit 5, Vlorë", 17, "Traditional home in the heart of Vlorë.", "Old Town Apartment", 95 },
                    { 55, null, "Port Road 7, Durrës", 18, "Luxury apartment with a stunning harbor view.", "Durrës Marina View", 120 },
                    { 56, null, "Amphitheater Street 10, Durrës", 18, "Unique stay near the ancient Roman amphitheater.", "Roman Amphitheater Stay", 100 },
                    { 57, null, "Golem Beach Road 4, Durrës", 18, "Cozy and peaceful apartment near the beach.", "Beachfront Serenity", 90 },
                    { 58, null, "Nikis Avenue 8, Thessaloniki", 20, "Amazing view of the iconic White Tower.", "White Tower View", 125 },
                    { 59, null, "Tsimiski Street 22, Thessaloniki", 20, "High-end apartment in the city center.", "Thessaloniki Luxury Loft", 140 },
                    { 60, null, "Nea Paralia 5, Thessaloniki", 20, "Relaxing stay right next to the Aegean Sea.", "Seafront Getaway", 130 },
                    { 61, null, "Agiou Nikolaou 10, Patras", 21, "Modern apartment in the heart of Patras.", "Patras City Center", 110 },
                    { 62, null, "Rio Beach 15, Patras", 21, "Relaxing stay with a beautiful sea view.", "Seaside Retreat", 130 },
                    { 63, null, "Old Town 7, Patras", 21, "Charming apartment near Patras Castle.", "Historic Patras Loft", 120 },
                    { 64, null, "Paleokastritsa Road 5, Corfu", 22, "Luxury stay with direct beach access.", "Corfu Beachfront Escape", 140 },
                    { 65, null, "Kapodistriou Street 9, Corfu", 22, "Traditional Corfiot apartment in the historic center.", "Old Town Charm", 130 },
                    { 66, null, "Gouvia Marina 2, Corfu", 22, "Exclusive apartment next to Corfu’s yacht marina.", "Luxury Marina Apartment", 150 }
                });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 11, 29, 51, 631, DateTimeKind.Utc).AddTicks(8155));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 66);

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 21, 32, 42, 142, DateTimeKind.Utc).AddTicks(3513));
        }
    }
}
