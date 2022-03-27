using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Data;
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
        private readonly IGameRepository active;
        public GameController(IGameRepository repository)
        {
            active = repository;
        }

        // POST api/game
        [HttpPost]
        public ActionResult<Game> PostNewGame()
        {
            return Ok(active.PostNewGame());
        }
    }
}