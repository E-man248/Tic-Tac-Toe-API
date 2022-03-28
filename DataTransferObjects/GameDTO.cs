using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.DataTransferObjects
{
    /** <summary>
        This class represents a Data Transfer Object for the
        Game object model. This Data Transfer Object enforces that
        only relevant data to the client will be returned when making
        transactions with the database.
    </summary> **/

    public class GameDTO
    {
        /// <summary> Unique player ID. </summary>
        [Key]
        public int gameID { get; set; }

        /** <summary>
            The current status of the game. This can be any of the following values:
            <list>
                <item>
                    <term> 0 | In Progress</term>
                    <description>This indicates the game has started, but
                    a winner has yet to be decided.</description>
                </item>
                <item>
                    <term> 1 | Player 1 Won</term>
                    <description>This indicates the game has been completed
                    and that it finished with player 1 declared the winner.</description>
                </item>
                <item>
                    <term> 2 | Player 2 Won</term>
                    <description>This indicates the game has been completed
                    and that it finished with player 2 declared the winner.</description>
                </item>
                <item>
                    <term> 3 | Draw</term>
                    <description>This indicates the game has been completed
                    but there was no winner.</description>
                </item>
            </list>
        </summary> **/
        [Required]
        public int status { get; set; }

        /** <summary>
            The unique player ID of the player assigned Player 1 in the game.
        </summary> **/
        [Required]
        public int player1ID { get; set; }

        /** <summary>
            The unique player ID of the player assigned Player 2 in the game.
        </summary> **/
        [Required]
        public int player2ID { get; set; }

        
        /** <summary>
            The player ID of the player whose turn it is to play.
        </summary> **/

        [Required]
        public int playerTurn { get; set; }
    }
}