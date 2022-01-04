using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    [Route("api/game")] //[controller]
    [ApiController]
    public class APIGamesController : ControllerBase
    {
        private ApplicationDbContext _context;
        public APIGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<UserModel> GetUser()    //GameModel, GetGame
        {
            return _context.Users.ToList();
        }
    }
}
