using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
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
            // If the game the move is made on does not exits, throw an exception:
            Game game = activeGameRepository.GetGame(gameID);
            if (game == null)
            {
                throw new ArgumentException("Game ID is INVALID!");
            }

            // If the player the move was made by does not exits, throw an exception:
            Player player = activeGameRepository.GetPlayer(playerID);
            if (player == null)
            {
                throw new ArgumentException("Player ID is INVALID!");
            }

            // If the player is not registered for the game throw an exception:
            if (player.playerID != game.player1ID && player.playerID != game.player2ID)
            {
                throw new ArgumentException("Player ID is INVALID!");
            }

            // Retrieve all moves from the selected game:
            List<Move> moves = activeGameRepository.GetAllMoves(game.gameID);

            // If the game the move is made on contains a move in the
            // exact same spot as is made, throw an exception:
            foreach (Move move in moves)
            {
                if (move.row == row && move.column == column)
                {
                    throw new ArgumentException("Move Position already taken!");
                }
            }

            // If the row and/or column are out of bounds, throw an exception:
            if (row < 0 || row >= 3 || column < 0 || column >= 3)
            {
                throw new ArgumentException("Move Position is INVALID!");
            }

            // Move can be safely created
            int gameStatus = activeGameRepository.PostNewMove(row, column, player.playerID, game, moves);
            
            var response = new
            {
                MoveInfo = "New Move at (" + row + "," + column + ")" + " registered for " + player.name + " in Game #" + game.gameID,
                Board_Row0 = GameLogicTracker.printBoardRow0(game, moves),
                Board_Row1 = GameLogicTracker.printBoardRow1(game, moves),
                Board_Row2 = GameLogicTracker.printBoardRow2(game, moves),
                GameStatus = gameStatus
            };

            return Created("Move Created", response);
        }

        // Endpoint 4:
        // GET api/game/{gameID}/move
        [HttpGet("{gameID}/move")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<MoveDTO>> GetAllMoves(int gameID)
        {
            // If the game the move is made on does not exits, throw an exception:
            Game game = activeGameRepository.GetGame(gameID);
            if (activeGameRepository.GetGame(gameID) == null)
            {
                throw new ArgumentException("Game ID is INVALID!");
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
            // If the game the move is made on does not exits, throw an exception:
            Player player = activeGameRepository.GetPlayer(playerID);
            if (activeGameRepository.GetPlayer(playerID) == null)
            {
                throw new ArgumentException("Player ID is INVALID!");
            }

            return Ok(activeMapper.Map<PlayerDTO>(player));
        }
    }
}