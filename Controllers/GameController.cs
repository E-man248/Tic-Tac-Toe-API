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

        // POST api/game
        [HttpPost]
        public ActionResult<GameDTO> PostNewGame()
        {
            var newGame = activeGameRepository.PostNewGame();
            if (newGame != null)
            {
                return Ok(activeMapper.Map<GameDTO>(newGame));
            }
            else return NotFound();
        }
    }
}