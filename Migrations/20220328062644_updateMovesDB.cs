using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class updateMovesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "letter",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "movePosition",
                table: "Moves");

            migrationBuilder.AddColumn<int>(
                name: "moveID",
                table: "Moves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "column",
                table: "Moves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "row",
                table: "Moves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "moveID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "moveID",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "column",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "row",
                table: "Moves");

            migrationBuilder.AddColumn<char>(
                name: "letter",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: ' ');

            migrationBuilder.AddColumn<string>(
                name: "movePosition",
                table: "Moves",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "movePosition");
        }
    }
}
