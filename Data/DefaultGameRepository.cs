using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    /** <summary>
        This class models a default implementation of a game repository. This
        is primarily used for testing functionality of the repository with safe
        values. This class is not intended for full product implementation.
    </summary> **/
    public class DefaultGameRepository : IGameRepository
    {
        public Game PostNewGame()
        {
            int[] defaultIDs = {0, 1};
            return new Game{gameID = 0, status = 0, player1ID = defaultIDs[0], player2ID = defaultIDs[1] };
        }
    }
}