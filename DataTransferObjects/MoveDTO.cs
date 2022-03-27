using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeAPI.Models
{
    /** <summary>
        This class represents a Data Transfer Object for the
        Move object model. This Data Transfer Object enforces that
        only relevant data to the client will be returned when making
        transactions with the database.
    </summary> **/
    public class MoveDTO
    {
        /** <summary>
            Move Position on the Tic-Tac-Toe Grid. Ex: A1
        </summary> **/
        public string movePosition { get; set; } = "";

        /** <summary>
            Player ID Foreign Key. This is the ID of the player
            that made the move.
        </summary> **/
        [ForeignKey("PlayerID")]
        public Player Player { get; set; }
        
        /// <summary> Game ID Foreign Key. </summary>
        [ForeignKey("GameID")]
        public Game Game { get; set; }
    }
}