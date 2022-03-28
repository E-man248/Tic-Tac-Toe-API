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
            // If the game the move is made on does not exits, throw an exception:
            Game game = activeGameRepository.GetGame(gameID);
            if (activeGameRepository.GetGame(gameID) == null)
            {
                throw new ArgumentException();
            }

            // If the player the move was made by does not exits, throw an exception:
            Player player = activeGameRepository.GetPlayer(playerID);
            if (activeGameRepository.GetGame(playerID) == null)
            {
                throw new ArgumentException();
            }

            // Retrieve all moves from the selected game:
            List<Move> moves = activeGameRepository.GetAllMoves(game.gameID);

            // If the game the move is made on contains a move in the
            // exact same spot as is made, throw an exception:
            foreach (Move move in moves)
            {
                if (move.row == row && move.column == column)
                {
                    throw new ArgumentException();
                }
            }

            // Move can be safely created
            int gameStatus = activeGameRepository.PostNewMove(row, column, player, game, moves);
            string uriResponse = "New Move at (" + row + "," + column + ")" + "registered for " + player.name + " in Game #" + game.gameID;

            return Created(uriResponse, gameStatus);
        }
    }
}