using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeAPI.Models
{
    /** <summary>
        This model represents the moves that the Player it is referencing
        makes and describes their decided move.
    </summary> **/
    public class Move
    {
        /** <summary>
            Player ID Foreign Key. This is the ID of the player
            that made the move.
        </summary> **/
        [ForeignKey("PlayerID")]
        public Player Player { get; set; }
        
        /// <summary> Game ID Foreign Key. </summary>
        [ForeignKey("GameID")]
        public Game Game { get; set; }

        /** <summary>
            Move Position on the Tic-Tac-Toe Grid. Ex: A1
        </summary> **/
        [Key]
        public string movePosition { get; set; } = "";
    }
}