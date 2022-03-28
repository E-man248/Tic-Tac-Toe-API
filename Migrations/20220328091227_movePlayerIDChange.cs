using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class movePlayerIDChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Players_PlayerID",
                table: "Moves");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Moves",
                newName: "playerID");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_PlayerID",
                table: "Moves",
                newName: "IX_Moves_playerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Players_playerID",
                table: "Moves",
                column: "playerID",
                principalTable: "Players",
                principalColumn: "playerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Players_playerID",
                table: "Moves");

            migrationBuilder.RenameColumn(
                name: "playerID",
                table: "Moves",
                newName: "PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Moves_playerID",
                table: "Moves",
                newName: "IX_Moves_PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Players_PlayerID",
                table: "Moves",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "playerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
