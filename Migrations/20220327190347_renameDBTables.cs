using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class renameDBTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_move_game_GameID",
                table: "move");

            migrationBuilder.DropForeignKey(
                name: "FK_move_player_PlayerID",
                table: "move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_player",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_move",
                table: "move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_game",
                table: "game");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "move",
                newName: "Moves");

            migrationBuilder.RenameTable(
                name: "game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_move_PlayerID",
                table: "Moves",
                newName: "IX_Moves_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_move_GameID",
                table: "Moves",
                newName: "IX_Moves_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "playerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moves",
                table: "Moves",
                column: "movePosition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "gameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Games_GameID",
                table: "Moves",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "gameID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Players_PlayerID",
                table: "Moves",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "playerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Games_GameID",
                table: "Moves");

            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Players_PlayerID",
                table: "Moves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moves",
                table: "Moves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "player");

            migrationBuilder.RenameTable(
                name: "Moves",
                newName: "move");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "game");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_PlayerID",
                table: "move",
                newName: "IX_move_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_GameID",
                table: "move",
                newName: "IX_move_GameID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_player",
                table: "player",
                column: "playerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_move",
                table: "move",
                column: "movePosition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_game",
                table: "game",
                column: "gameID");

            migrationBuilder.AddForeignKey(
                name: "FK_move_game_GameID",
                table: "move",
                column: "GameID",
                principalTable: "game",
                principalColumn: "gameID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_move_player_PlayerID",
                table: "move",
                column: "PlayerID",
                principalTable: "player",
                principalColumn: "playerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
