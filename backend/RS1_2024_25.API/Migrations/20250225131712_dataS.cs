using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class dataS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 4,
                column: "ApartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 5,
                column: "ApartmentId",
                value: 5);

            migrationBuilder.InsertData(
                table: "ApartmentImages",
                columns: new[] { "ApartmentImageID", "ApartmentId", "ImageID" },
                values: new object[,]
                {
                    { 6, 6, 1 },
                    { 7, 7, 2 },
                    { 8, 8, 3 },
                    { 9, 9, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 25, 13, 17, 10, 957, DateTimeKind.Utc).AddTicks(3175));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 4,
                column: "ApartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApartmentImages",
                keyColumn: "ApartmentImageID",
                keyValue: 5,
                column: "ApartmentId",
                value: 3);

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
    }
}
