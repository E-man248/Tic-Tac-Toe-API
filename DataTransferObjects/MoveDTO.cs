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
            Unique ID of the move.
        </summary> **/
        [Key]
        public int moveID { get; set; }

        /** <summary>
            Row Position on the Tic-Tac-Toe Grid.
        </summary> **/
        [Required]
        public int row { get; set; }
        
        /** <summary>
            Column Position on the Tic-Tac-Toe Grid.
        </summary> **/
        [Required]
        public int column { get; set; }

        /** <summary>
            Player ID Foreign Key. This is the ID of the player
            that made the move.
        </summary> **/
        [ForeignKey("Player")]
        [Required]
        public int playerID  { get; set; }
        private Player Player { get; set; }
        
        /// <summary> Game ID Foreign Key. </summary>
        [ForeignKey("GameID")]
        [Required]
        public Game Game { get; set; }
    }
}