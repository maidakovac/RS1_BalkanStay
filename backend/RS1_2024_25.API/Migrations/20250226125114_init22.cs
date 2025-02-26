using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/image2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "ImagePath",
                value: "/images/room1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "ImagePath",
                value: "/images/toilet2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "ImagePath",
                value: "/images/room1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "ImagePath",
                value: "/images/image2.jpg");

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 51, 13, 324, DateTimeKind.Utc).AddTicks(5091));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 1,
                column: "ImagePath",
                value: "./images/image2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 2,
                column: "ImagePath",
                value: "./images/room1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 3,
                column: "ImagePath",
                value: "./images/toilet2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 4,
                column: "ImagePath",
                value: "./images/room1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: 5,
                column: "ImagePath",
                value: "./images/image2.jpg");

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 26, 12, 5, 30, 872, DateTimeKind.Utc).AddTicks(1673));
        }
    }
}
