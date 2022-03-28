using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    public partial class movePlayerIDChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Players_playerID",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_playerID",
                table: "Moves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Moves_playerID",
                table: "Moves",
                column: "playerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Players_playerID",
                table: "Moves",
                column: "playerID",
                principalTable: "Players",
                principalColumn: "playerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
