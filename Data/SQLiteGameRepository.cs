using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    /** <summary>
        This class acts as a game repository, integrating the SQLite Database
        Architecture. This repository has been made separately so that there
        is a loose connection between it and the database context used.
        This repository is linked to the database context through the
        Game Repository interface so that other classes are aware of its features
        without needing to make them dependent on its implementation.
    </summary> **/
    public class SQLiteGameRepository : IGameRepository
    {
        private readonly GameDatabaseContext activeDatabaseContext;

        public SQLiteGameRepository(GameDatabaseContext databaseContext)
        {
            activeDatabaseContext = databaseContext;
        }

        public Game PostNewGame()
        {
            return new Game();
        }
    }
}