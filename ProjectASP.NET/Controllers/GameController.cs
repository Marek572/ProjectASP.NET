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
            return View();            
        }

        [HttpPost]
        public IActionResult Add(GameModel game)
        {
            if (ModelState.IsValid)
            {
                return View("ConfirmGame", repository.AddGame(game));
            }
            else
            {
                return View("AddGame");
            }

        }

        public IActionResult Index()
        {
            return View(repository.FindAllGames());
        }

        public IActionResult EditGame(int id)
        {
            return View(repository.FindGameById(id));
        }

        public IActionResult Edit(GameModel game, UserModel user)
        {
            repository.UpdateGame(game, user);
            return View("Index", repository.FindAllGames());
        }

        public IActionResult DeleteGame(int id)
        {
            repository.DeleteGame(id);
            return View("Index", repository.FindAllGames());
        }
    }
}
