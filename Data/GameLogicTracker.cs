using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    public class GameLogicTracker
    {
        char[,] board;

        private void populateBoard()
        {
            board = new char[3,3];
        }

        public static int UpdateGameStatus(Game game, List<Move> moves)
        {
            return 0;
        }
    }
}