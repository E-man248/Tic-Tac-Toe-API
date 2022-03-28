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

        /** <summary> Inherited from Interface IGameRepository </summary> **/
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
            newGame.status = 0;
            newGame.playerTurn = newPlayer1.playerID;
            activeDatabaseContext.Games.Add(newGame);
            activeDatabaseContext.SaveChanges();

            return newGame;
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public Player? GetPlayer(int playerID)
        {
            return activeDatabaseContext.Players.Find(playerID);
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public Game? GetGame(int gameID)
        {
            return activeDatabaseContext.Games.Find(gameID);
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public int PostNewMove(int row, int column, int playerID, Game game, List<Move> moves)
        {
            // Create Move and Attach Keys:
            Move newMove = new Move();
            newMove.row = row;
            newMove.column = column;
            newMove.Game = game;
            newMove.playerID = playerID;

            // Add Move to Database:
            activeDatabaseContext.Moves.Add(newMove);
            activeDatabaseContext.SaveChanges();
            moves.Add(newMove);

            // Change Game Status and Player Turn:
            int gameStatus = GameLogicTracker.GetGameStatus(game, moves);
            game.status = gameStatus;
            if (game.playerTurn == game.player1ID) game.playerTurn = game.player2ID;
            else game.playerTurn = game.player1ID;

            // Update the Game the Move took place in:
            activeDatabaseContext.Games.Update(game);
            activeDatabaseContext.SaveChanges();

            return gameStatus;
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public bool SaveDBChanges()
        {
            return activeDatabaseContext.SaveChanges() >= 0;
        }

        /** <summary> Inherited from Interface IGameRepository </summary> **/
        public List<Move> GetAllMoves(int gameID)
        {
            return activeDatabaseContext.Moves.Where(move => move.Game.gameID == gameID).ToList();
        }
    }
}