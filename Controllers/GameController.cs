using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Data;
using TicTacToeAPI.DataTransferObjects;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Controllers
{
    /** <summary>
        This Controller handles HTTP Requests relating to Game models
        stored in the database.
    </summary> **/

    [Route("api/[Controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository activeGameRepository;
        private readonly IMapper activeMapper;

        public GameController(IGameRepository repository, IMapper mapper)
        {
            activeGameRepository = repository;
            activeMapper = mapper;
        }

        // Endpoint 1:
        // POST api/game
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<GameDTO> PostNewGame(string? player1Name, string? player2Name)
        {
            if (player1Name == null || player1Name.Length == 0)
            {
                player1Name = "Player 1";
            }
            
            if (player2Name == null || player2Name.Length == 0)
            {
                player2Name = "Player 2";
            }

            var newGame = activeGameRepository.PostNewGame(player1Name, player2Name);
            string uriResponse = "Player 1 Name : " + player1Name + "Player 2 Name : " + player2Name;

            return Created(uriResponse, activeMapper.Map<GameDTO>(newGame));
        }
        
        // Endpoint 2:
        // POST api/game/{gameID}/move
        [HttpPost("{gameID}/move")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> PostNewMove(int row, int column, int playerID, int gameID)
        {
            // If the game the move is made on does not exits, throw an error:
            Game game = activeGameRepository.GetGame(gameID);
            if (game == null)
            {
                return BadRequest("ERROR: Game ID is INVALID!");
            }

            // If the player the move was made by does not exits, throw an error:
            Player player = activeGameRepository.GetPlayer(playerID);
            if (player == null)
            {
                return BadRequest("ERROR: Player ID is INVALID!");
            }

            // If the player is not registered for the game throw an error:
            if (player.playerID != game.player1ID && player.playerID != game.player2ID)
            {
                return BadRequest("ERROR: Player is not registered for this game!");
            }

            // Retrieve all moves from the selected game:
            List<Move> moves = activeGameRepository.GetAllMoves(game.gameID);

            // If the game is already over, throw an error:
            if (game.status != 0)
            {
                string errorGameStatusMessage = "Game Still In Progress...";

                if (game.status == 1) errorGameStatusMessage = "Player 1 Wins!";
                else if (game.status == 2) errorGameStatusMessage = "Player 2 Wins!";
                else if (game.status == 3) errorGameStatusMessage = "Game was a Draw!";

                var invalidStatusResponse = new
                {
                    ERROR = "This game has already been completed!",
                    Board_Row0 = GameLogicTracker.printBoardRow0(game, moves),
                    Board_Row1 = GameLogicTracker.printBoardRow1(game, moves),
                    Board_Row2 = GameLogicTracker.printBoardRow2(game, moves),
                    GameStatus = errorGameStatusMessage
                };
                return BadRequest(invalidStatusResponse);
            }

            // If it is not the turn for the selected player, throw an error:
            if (game.playerTurn != player.playerID)
            {
                var invalidTurnResponse = new
                {
                    ERROR = "It is not this player's turn!",
                    NextTurn = activeGameRepository.GetPlayer(game.playerTurn).name,
                    PlayerID = game.playerTurn
                };
                return BadRequest(invalidTurnResponse);
            }

            // If the game the move is made on contains a move in the
            // exact same spot as is made, throw an error:
            foreach (Move move in moves)
            {
                if (move.row == row && move.column == column)
                {
                    return BadRequest("ERROR: Move Position already taken!");
                }
            }

            // If the row and/or column are out of bounds, throw an error:
            if (row < 0 || row >= 3 || column < 0 || column >= 3)
            {
                return BadRequest("ERROR: Move Position is INVALID!");
            }

            // Move can be safely created
            int gameStatus = activeGameRepository.PostNewMove(row, column, player.playerID, game, moves);
            moves = activeGameRepository.GetAllMoves(game.gameID);

            string gameStatusMessage = "Game Still In Progress...";

            if (game.status == 1) gameStatusMessage = "Player 1 Wins!";
            else if (game.status == 2) gameStatusMessage = "Player 2 Wins!";
            else if (game.status == 3) gameStatusMessage = "Game was a Draw!";
            
            var response = new
            {
                MoveInfo = "New Move at (" + row + "," + column + ")" + " registered for " + player.name + " in Game #" + game.gameID,
                Board_Row0 = GameLogicTracker.printBoardRow0(game, moves),
                Board_Row1 = GameLogicTracker.printBoardRow1(game, moves),
                Board_Row2 = GameLogicTracker.printBoardRow2(game, moves),
                GameStatus = gameStatusMessage,
                NextTurn = game.playerTurn
            };

            return Created("Move Created", response);
        }

        // This helper class stores information about games including their
        // game model, number of moves, and their players' names.
        public class GameInfo
        {
            public Game Game { get; set; }
            public int NumberOfMoves { get; set; }
            public string Player1Name  { get; set; }
            public string Player2Name { get; set; }
            public string GameRow0 { get; set; }
            public string GameRow1 { get; set; }
            public string GameRow2 { get; set; }
        }

        // Endpoint 3: 
        // GET api/game
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<GameInfo>> GetAllActiveGames()
        {
            // Retrieve all active games from the database:
            List<Game> games = activeGameRepository.GetAllActiveGames();

            List<GameInfo> gameInfoList = new List<GameInfo>();

            foreach (Game game in games) 
            {
                // Store game information:
                GameInfo gameInfo = new GameInfo();
                List<Move> moves = activeGameRepository.GetAllMoves(game.gameID);

                gameInfo.Game = game;
                gameInfo.Player1Name = activeGameRepository.GetPlayer(game.player1ID).name;
                gameInfo.Player2Name = activeGameRepository.GetPlayer(game.player2ID).name;
                gameInfo.NumberOfMoves = moves.Count;
                gameInfo.GameRow0 = GameLogicTracker.printBoardRow0(game, moves);
                gameInfo.GameRow1 = GameLogicTracker.printBoardRow1(game, moves);
                gameInfo.GameRow2 = GameLogicTracker.printBoardRow2(game, moves);


                gameInfoList.Add(gameInfo);
            }

            return Ok(gameInfoList);
        }

        // Endpoint 4: 
        // GET api/game/{gameID}/move
        [HttpGet("{gameID}/move")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<MoveDTO>> GetAllMoves(int gameID)
        {
            // If the game does not exits, throw an exception:
            Game game = activeGameRepository.GetGame(gameID);
            if (activeGameRepository.GetGame(gameID) == null)
            {
                return BadRequest("ERROR: Game ID is INVALID!");
            }

            // Retrieve all moves from the selected game:
            List<Move> moves = activeGameRepository.GetAllMoves(game.gameID);

            return Ok(activeMapper.Map<List<MoveDTO>>(moves));
        }

        // Endpoint 5:
        // GET api/game/player/{playerID}
        [HttpGet("player/{playerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PlayerDTO> GetPlayer(int playerID)
        {
            // If player does not exits, throw an error:
            Player player = activeGameRepository.GetPlayer(playerID);
            if (activeGameRepository.GetPlayer(playerID) == null)
            {
                return BadRequest("ERROR: Player ID is INVALID!");
            }

            return Ok(activeMapper.Map<PlayerDTO>(player));
        }
    }
}