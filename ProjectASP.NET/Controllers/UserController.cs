using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    public class UserController : Controller
    {
        private ICRUDUserRepository repository;

        public UserController(ICRUDUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.FindAllUsers());
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return View("ConfirmUser");
            }
            else
            {
                return View("AddUser");
            }

        }
    }
}
