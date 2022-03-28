using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    /** <summary>
        This class represents a Data Transfer Object for the
        Player object model. This Data Transfer Object enforces that
        only relevant data to the client will be returned when making
        transactions with the database.
    </summary> **/
    public class PlayerDTO
    {
        /// <summary> Unique player ID. </summary>
        [Key]
        public int playerID { get; set; }

        /// <summary> Optional player name. </summary>
        [MaxLength(255)]
        public string? name { get; set; } = "Guest";
    }
}