using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectASP.NET.Filter;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    [DisableBasic]
    public class GameController : Controller
    {
        private ICRUDGameRepository repository;

        public GameController(ICRUDGameRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult AddGame()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View();            
        }

        [HttpPost]
        public IActionResult Add(GameModel game)
        {
            if (ModelState.IsValid)
            {
                ViewData["Username"] = HttpContext.Session.GetString("Username");
                return View("ConfirmGame", repository.AddGame(game));
            }
            else
            {
                ViewData["Username"] = HttpContext.Session.GetString("Username");
                return View("AddGame");
            }

        }

        public IActionResult Index()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View(repository.FindAllGames());
        }

        public IActionResult EditGame(int id)
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View(repository.FindGameById(id));
        }

        public IActionResult Edit(GameModel game, UserModel user)
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            repository.UpdateGame(game, user);
            return View("Index", repository.FindAllGames());
        }

        public IActionResult DeleteGame(int id)
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            repository.DeleteGame(id);
            return View("Index", repository.FindAllGames());
        }
    }
}
