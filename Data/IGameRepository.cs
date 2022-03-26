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
        Game PostNewGame();
    }
}