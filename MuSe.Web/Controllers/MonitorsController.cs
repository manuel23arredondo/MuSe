namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Threading.Tasks;

    public class MonitorsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;
        private readonly IImageHelper imageHelper;

        public MonitorsController(DataContext dataContext, IImageHelper imageHelper, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
            this.userHelper = userHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dataContext.Monitors
                .Include(t => t.User)
                .ToListAsync());
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
        public async Task<IActionResult> Create(MonitorViewModel model)
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
                        await userHelper.AddUserToRoleAsync(user, "Monitor");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "La contraseña debe tener al menos 6 caracteres");
                        return View(model);
                    }

                    if (result == IdentityResult.Success)
                    {
                        var monitor = new Monitor
                        {
                            Id = model.Id,
                            ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                            model.ImageFile,
                            model.User.FullName,
                            "monitors") : string.Empty),
                            User = await this.dataContext.Users.FindAsync(user.Id)
                        };
                        dataContext.Add(monitor);
                        await dataContext.SaveChangesAsync();
                        return RedirectToAction(nameof(AccountCreated));
                    }
                    ModelState.AddModelError(string.Empty, "El email ingresado no está disponible");
                }
            }
            return View(model);
        }
    }
}