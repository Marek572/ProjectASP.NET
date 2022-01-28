using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Filter;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    [DisableBasic]
    public class UserController : Controller
    {
        private readonly ICRUDUserRepository repository;

        public UserController(ICRUDUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View("Index",repository.FindAllUsers());
        }

        public IActionResult EditUserPage(string id)
        {
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View(repository.FindUserById(id));
        }
    }
}
