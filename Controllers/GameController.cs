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
    }
}