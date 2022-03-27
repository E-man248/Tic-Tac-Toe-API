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
        public int playerID { get; set; }
        
        /// <summary> Game ID Foreign Key. </summary>
        public int gameID { get; set; }

        /** <summary>
            Move Position on the Tic-Tac-Toe Grid. Ex: A1
        </summary> **/
        public string movePosition { get; set; } = "";
    }
}