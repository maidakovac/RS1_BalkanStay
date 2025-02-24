using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentImageSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApartmentImages",
                columns: new[] { "ApartmentImageID", "ApartmentId", "ImageID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 22, 7, 11, 920, DateTimeKind.Utc).AddTicks(5574));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 24, 17, 33, 31, 779, DateTimeKind.Utc).AddTicks(1589));
        }
    }
}
