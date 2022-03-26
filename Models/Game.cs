namespace TicTacToeAPI.Models
{
    /** <summary>
        This model represents a Game and details information about players
        involved in the game as well as the current game status.
    </summary> **/
    public class Game
    {
        /// <summary> Unique player ID. </summary>
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
            </list>
        </summary> **/
        public int status { get; set; }

        /** <summary>
            The two unique player IDs of the players involved in a game.
        </summary> **/
        public int[] playerIDs = new int[2];
    }
}