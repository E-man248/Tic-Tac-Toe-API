using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    /** <summary>
        This model represents the Player and details their game information.
    </summary> **/
    public class Player
    {
        /// <summary> Unique player ID. </summary>
        [Key]
        public int playerID { get; set; }

        /// <summary> Optional player name. </summary>
        [MaxLength(255)]
        public string? name { get; set; } = "Guest";

        /** <summary>
            Assigned player letter icon. This will either 'X' or 'O' and
            represent the player's moves in the game.
        </summary> */
        public char letter { get; set; }
    }
}