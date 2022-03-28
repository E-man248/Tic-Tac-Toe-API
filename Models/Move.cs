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
        [ForeignKey("PlayerID")]
        [Required]
        public Player Player { get; set; }
        
        /// <summary> Game ID Foreign Key. </summary>
        [ForeignKey("GameID")]
        [Required]
        public Game Game { get; set; }
    }
}