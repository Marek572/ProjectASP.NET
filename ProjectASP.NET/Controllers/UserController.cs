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

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return View("ConfirmUser", repository.AddUser(user));
            }
            else
            {
                return View("AddUser");
            }

        }

        public IActionResult Index()
        {
            return View(repository.FindAllUsers());
        }

        public IActionResult EditUser(int id)
        {
            return View(repository.FindUserById(id));
        }

        public IActionResult Edit(UserModel user)
        {
            repository.UpdateUser(user);
            return View("Index", repository.FindAllUsers());
        }

        public IActionResult DeleteUser(int id)
        {
            repository.DeleteUser(id);
            return View("Index", repository.FindAllUsers());
        }
    }
}
