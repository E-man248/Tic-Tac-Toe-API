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
        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public List<Move> GetAllMoves(int gameID)
        {
            throw new NotImplementedException();
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public Game? GetGame(int gameID)
        {
            throw new NotImplementedException();
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public Player? GetPlayer(int playerID)
        {
            throw new NotImplementedException();
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public Game PostNewGame(string player1Name, string player2Name)
        {
            int[] defaultIDs = {0, 1};
            return new Game{gameID = 0, status = 0, player1ID = defaultIDs[0], player2ID = defaultIDs[1] };
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public int PostNewMove(int row, int column, int playerID, Game game, List<Move> moves)
        {
            throw new NotImplementedException();
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public bool SaveDBChanges()
        {
            throw new NotImplementedException();
        }
    }
}