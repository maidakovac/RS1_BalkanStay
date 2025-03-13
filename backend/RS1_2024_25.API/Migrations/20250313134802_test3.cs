using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 48, 1, 701, DateTimeKind.Utc).AddTicks(3350));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 46, 49, 743, DateTimeKind.Utc).AddTicks(2187));
        }
    }
}
