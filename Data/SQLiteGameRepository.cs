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

        public Game PostNewGame(string player1Name, string player2Name)
        {
            // Create players of the game and add them:
            Player newPlayer1 = new Player();
            newPlayer1.name = player1Name;
            activeDatabaseContext.Players.Add(newPlayer1);
            activeDatabaseContext.SaveChanges();

            Player newPlayer2 = new Player();
            newPlayer2.name = player2Name;
            activeDatabaseContext.Players.Add(newPlayer2);
            activeDatabaseContext.SaveChanges();

            // Create the game and add players to that game:
            Game newGame = new Game();
            newGame.player1ID = newPlayer1.playerID;
            newGame.player2ID = newPlayer2.playerID;
            activeDatabaseContext.Games.Add(newGame);
            activeDatabaseContext.SaveChanges();

            return newGame;
        }

        public bool SaveDBChanges()
        {
            return activeDatabaseContext.SaveChanges() >= 0;
        }
    }
}