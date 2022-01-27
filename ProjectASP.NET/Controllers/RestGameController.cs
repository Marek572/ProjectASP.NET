using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Filter;
using ProjectASP.NET.Interfaces;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    [Route("api/games")]
    [ApiController]
    [AllowAnonymous]
    public class RestController : ControllerBase
    {
        private ICRUDRestRepository _restRepository;
        public RestController(ICRUDRestRepository restRepository)
        {
            _restRepository = restRepository;
        }

        [DisableBasic]
        [HttpPost]
        public GameModel AddGame([FromBody] GameModel game)
        {
            _restRepository.AddGame(game);
            return game;
        }

        [DisableBasic]
        [HttpGet]
        [Route("{id}")]
        public GameModel FindGameById(int id)
        {
            return _restRepository.FindGameById(id);
        }

        [DisableBasic]
        [HttpGet]
        public List<GameModel> FindAllGames()
        {
            return _restRepository.FindAllGames();
        }

        [HttpPut("{id}")]
        public ActionResult<GameModel> UpdateGame([FromBody] GameModel game)
        {
            GameModel before = _restRepository.UpdateGame(game);
            return before;
        }

        [HttpDelete]
        [Route("{id}")]
        public GameModel DeleteGame(int id)
        {
            _restRepository.DeleteGame(id);
            return _restRepository.FindGameById(id);
        }
    }
}