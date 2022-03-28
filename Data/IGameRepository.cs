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
            Newly created instance of the game that was saved.
        </returns>**/
        Game PostNewMove(int row, int column);

        /** <summary>
            This method save any changes to the database.
        </summary>**/
        bool SaveDBChanges();
    }
}