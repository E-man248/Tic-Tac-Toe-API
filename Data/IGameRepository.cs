using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    /** <summary>
        This interface enforces the methods that should be implemented in
        a Game Repository so that classes implementing this interface are
        implement these methods.
    </summary> **/
    public interface IGameRepository
    {
        /** <summary>
            This method creates a game and saves that game to the repository.
        </summary>
        <returns>
            Newly created instance of the game that was saved.
        </returns>**/
        Game PostNewGame(string player1Name, string player2Name);

        /** <summary>
            This method registers a move and saves it to the repository.
        </summary>**/
        ///<param name="row"> The row on the grid that the move will be placed in. </param>
        ///<param name="column"> The column on the grid that the move will be placed in. </param>
        /**<returns>
            Status code of the game after the move has been made.
        </returns>**/
        int PostNewMove(int row, int column, int playerID, Game game, List<Move> moves);

        /** <summary>
            This method save any changes to the database.
        </summary>**/
        bool SaveDBChanges();

        /** <summary>
            This method retrieves a player from the database.
        </summary>**/
        Player? GetPlayer(int playerID);

        /** <summary>
            This method retrieves a game from the database.
        </summary>**/
        Game? GetGame(int gameID);
        
        /** <summary>
            This method retrieves all the moves that take place in a game from the database.
        </summary>**/
        List<Move> GetAllMoves(int gameID);

        /** <summary>
            This method retrieves all the games are currently taking place in the database.
        </summary>**/
        public List<Game> GetAllActiveGames();
    }
}