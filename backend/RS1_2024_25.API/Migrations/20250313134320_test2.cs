using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 43, 18, 728, DateTimeKind.Utc).AddTicks(6515));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 599, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 599, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "AccountID",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 599, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 598, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 598, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 598, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "AccountID",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 13, 13, 23, 57, 598, DateTimeKind.Utc).AddTicks(9169));
        }
    }
}
