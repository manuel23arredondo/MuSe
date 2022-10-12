﻿namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult NotAuthorized()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model.Email,
                    model.Password, model.RememberMe);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }
                this.ModelState.AddModelError(string.Empty, "Email/Contraseña incorrecta");
                return this.View(model);
            }
            return this.View(model);
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
