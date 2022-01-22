using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectASP.NET.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ICRUDUserRepository _repository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 ICRUDUserRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var identityUser = new IdentityUser { UserName = model.Username, Email = model.Email};
                var result = await _userManager.CreateAsync(identityUser, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    UserModel user = new UserModel()
                    {
                        UserId = identityUser.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        BirthDate = model.BirthDate,
                        Phone = model.Phone,
                        Username = model.Username,
                        Email = model.Email
                    };
                    _repository.AddUser(user);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await
               _userManager.FindByNameAsync(loginModel.Username);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Login and password doesn't match");
            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var IdentityUser = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(IdentityUser);
            if(result.Succeeded)
            {
                _repository.DeleteUser(id);
                await _signInManager.SignOutAsync();
            }
            return View("../Home/Index", _repository.FindAllUsers());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> EditUserData(UserModel user)
        {
            IdentityUser IUser = await _userManager.FindByIdAsync(user.UserId);
            var EmailResult = await _userManager.ChangeEmailAsync(IUser, user.Email, null);
            var UserNameResult = await _userManager.SetUserNameAsync(IUser, user.Username);
            if(EmailResult.Succeeded && UserNameResult.Succeeded)
            {
                _repository.UpdateUser(user);
            }
            return View("../User/Index", _repository.FindAllUsers());
        }
    }
}
