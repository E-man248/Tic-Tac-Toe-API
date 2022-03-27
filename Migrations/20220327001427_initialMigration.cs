using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    gameID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    player1ID = table.Column<int>(type: "INTEGER", nullable: false),
                    player2ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.gameID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
