using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class moveDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_games",
                table: "games");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "player");

            migrationBuilder.RenameTable(
                name: "games",
                newName: "game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_player",
                table: "player",
                column: "playerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_game",
                table: "game",
                column: "gameID");

            migrationBuilder.CreateTable(
                name: "move",
                columns: table => new
                {
                    movePosition = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false),
                    GameID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_move", x => x.movePosition);
                    table.ForeignKey(
                        name: "FK_move_game_GameID",
                        column: x => x.GameID,
                        principalTable: "game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_move_player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "player",
                        principalColumn: "playerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_move_GameID",
                table: "move",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_move_PlayerID",
                table: "move",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_game",
                table: "game");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "players");

            migrationBuilder.RenameTable(
                name: "game",
                newName: "games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "playerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_games",
                table: "games",
                column: "gameID");
        }
    }
}
