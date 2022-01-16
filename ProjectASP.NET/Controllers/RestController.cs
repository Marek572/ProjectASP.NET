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
    public class RestController : ControllerBase
    {
        private ApplicationDbContext _context;
        public RestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ApiModel AddGame([FromBody] ApiModel game)
        {
            var entity = _context.Api.Add(game).Entity;
            _context.SaveChanges();
            return entity;
        }

        [HttpGet]
        public List<ApiModel> GetGame()
        {
            return _context.Api.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<ApiModel> EditGame(int id, [FromBody] ApiModel game)
        {
            var x = _context.Api.Where(s => s.GameId == id).FirstOrDefault();

            if (x != null)
            {
                x.Availability = game.Availability;
                x.genre = game.genre;
                x.Developer = game.Developer;
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
        public ApiModel DeleteGame(int id)
        {
            var game = _context.Api.Where(s => s.GameId == id).First();
            _context.Remove(game);
            _context.SaveChanges();
            return game;
        }
    }
}