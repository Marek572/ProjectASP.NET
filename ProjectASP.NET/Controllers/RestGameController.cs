using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private ApplicationDbContext _context;
        public RestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public GameModel AddGame([FromBody] GameModel game)
        {
            var entity = _context.Games.Add(game).Entity;
            _context.SaveChanges();
            return entity;
        }

        [HttpGet]
        public List<GameModel> GetGame()
        {
            return _context.Games.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<GameModel> EditGame(int id, [FromBody] GameModel game)
        {
            var x = _context.Games.Where(s => s.GameId == id).FirstOrDefault();

            if (x != null)
            {
                x.Availability = game.Availability;
                x.Title = game.Title;
                x.genre = game.genre;
                x.Platform = game.Platform;
                x.Developer = game.Developer;
                x.Publisher = game.Publisher;
                x.UserName = game.UserName;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public GameModel DeleteGame(int id)
        {
            var game = _context.Games.Where(s => s.GameId == id).First();
            _context.Remove(game);
            _context.SaveChanges();
            return game;
        }
    }
}