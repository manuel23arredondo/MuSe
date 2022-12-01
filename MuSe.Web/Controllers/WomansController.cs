namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Threading.Tasks;

    public class WomansController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly IImageHelper imageHelper;
        private readonly IWomanRepository repository;

        public WomansController(IWomanRepository repository, IImageHelper imageHelper, IUserHelper userHelper)
        {
            this.imageHelper = imageHelper;
            this.userHelper = userHelper;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetWomanWithUsers());
        }

        public IActionResult AccountCreated()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WomanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userHelper.GetUserByIdAsync(model.User.Id);
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.User.FirstName,
                        LastName = model.User.LastName,
                        PhoneNumber = model.User.PhoneNumber,
                        BirhtDate = model.User.BirhtDate,
                        Email = model.User.Email,
                        UserName = model.User.Email
                    };
                    string contrasenia = model.Contrasenia;

                    var result = await userHelper.AddUserAsync(user, contrasenia);

                    try
                    {
                        await userHelper.AddUserToRoleAsync(user, "Woman");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "La contraseña debe tener al menos 6 caracteres");
                        return View(model);
                    }

                    if (result == IdentityResult.Success)
                    {
                        var woman = new Woman
                        {
                            Id = model.Id,
                            ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                            model.ImageFile,
                            model.User.FullName,
                            "womans") : string.Empty),
                            User = await this.repository.GetUserByIdAsync(user.Id)
                        };
                        await this.repository.CreateAsync(woman);
                        return RedirectToAction(nameof(AccountCreated));
                    }
                    ModelState.AddModelError(string.Empty, "El email ingresado no está disponible");
                }
            }
            return View(model);
        }

    }
}