using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "MyAppUsers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "MyAppUsers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "MyAppUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MyAppUsers",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "MyAppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderID",
                table: "MyAppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MyAppUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_MyAppUsers_CityID",
                table: "MyAppUsers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_MyAppUsers_GenderID",
                table: "MyAppUsers",
                column: "GenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_MyAppUsers_Cities_CityID",
                table: "MyAppUsers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MyAppUsers_Gender_GenderID",
                table: "MyAppUsers",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "GenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyAppUsers_Cities_CityID",
                table: "MyAppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MyAppUsers_Gender_GenderID",
                table: "MyAppUsers");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_MyAppUsers_CityID",
                table: "MyAppUsers");

            migrationBuilder.DropIndex(
                name: "IX_MyAppUsers_GenderID",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "GenderID",
                table: "MyAppUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MyAppUsers");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "MyAppUsers",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MyAppUsers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "MyAppUsers",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "MyAppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "MyAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "MyAppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "MyAppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
