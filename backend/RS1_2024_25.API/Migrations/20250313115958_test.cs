using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 59, 56, 468, DateTimeKind.Utc).AddTicks(4996));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 862, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 11, 52, 40, 863, DateTimeKind.Utc).AddTicks(151));
        }
    }
}
