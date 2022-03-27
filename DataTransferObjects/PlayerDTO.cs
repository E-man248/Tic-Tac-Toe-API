using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    /** <summary>
        This class represents a Data Transfer Object for the
        Game object model. This Data Transfer Object enforces that
        only relevant data to the client will be returned when making
        transactions with the database.
    </summary> **/
    public class PlayerDTO
    {
        /// <summary> Unique player ID. </summary>
        public int playerID { get; set; }

        /// <summary> Optional player name. </summary>
        public string name { get; set; } = "Guest";

        /** <summary>
            Assigned player letter icon. This will either 'X' or 'O' and
            represent the player's moves in the game.
        </summary> */
        public char letter { get; set; }
    }
}