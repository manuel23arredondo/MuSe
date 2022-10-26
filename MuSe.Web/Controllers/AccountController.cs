namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Security.Cryptography;
    using System.Text;
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

        [HttpGet]
        public IActionResult MyProfile()
        {
            return this.View();
        }

        //[HttpGet]
        //public IActionResult StartRecovery()
        //{
        //    RecoveryViewModel model = new RecoveryViewModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult StartRecovery(RecoveryViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View(model);

        //    }

        //    string token = GetSha256(Guid.NewGuid().ToString());

        //    return View();
        //}

        //public IActionResult Recovery()
        //{
        //    return View();
        //}

        //#region HELPERS
        //private string GetSha256(string str)
        //{
        //    SHA256 sha256 = SHA256Managed.Create();
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    byte[] stream = null;
        //    StringBuilder sb = new StringBuilder();
        //    stream = sha256.ComputeHash(encoding.GetBytes(str));
        //    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        //    return sb.ToString();
        //}

        //#endregion
    }
}