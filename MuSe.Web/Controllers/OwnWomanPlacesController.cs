namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Data;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System.Data;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System;

    [Authorize(Roles = "Woman,Monitor")]
    public class OwnWomanPlacesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IOwnWomanPlaceRepository repository;

        public OwnWomanPlacesController(IOwnWomanPlaceRepository repository,
            ICombosHelper combosHelper, DataContext dataContext)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsers(User.Identity.Name));
        }

        [Authorize(Roles = "Woman")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new OwnWomanPlaceViewModel
            {
                KindOfPlaces = this.combosHelper.GetComboKindOfPlaces()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OwnWomanPlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ownWomanPlace = new OwnWomanPlace
                {
                    Latitud = model.Latitud,
                    Longitude = model.Longitude,
                    Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                    KindOfPlace = await this.repository.GetKindOfPlacesByIdAsync(model.KindOfPlaceId)
                };
                await this.repository.CreateAsync(ownWomanPlace);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownWomanPlace = await this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(id.Value);

            if (ownWomanPlace == null)
            {
                return NotFound();
            }

            var model = new OwnWomanPlaceViewModel
            {
                Longitude = ownWomanPlace.Longitude,
                Latitud = ownWomanPlace.Latitud,
                KindOfPlace = ownWomanPlace.KindOfPlace,
                KindOfPlaceId = ownWomanPlace.KindOfPlace.Id,
                Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                KindOfPlaces = this.combosHelper.GetComboKindOfPlaces()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OwnWomanPlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ownWomanPlace = new OwnWomanPlace
                {
                    Id = model.Id,
                    Latitud = model.Latitud,
                    Longitude = model.Longitude,
                    Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                    KindOfPlace = await this.repository.GetKindOfPlacesByIdAsync(model.KindOfPlaceId)
                };

                await this.repository.UpdateAsync(ownWomanPlace);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownWomanPlace = await this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(id.Value);

            if (ownWomanPlace == null)
            {
                return NotFound();
            }
            return View(ownWomanPlace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownWomanPlace = await this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(id);

            try
            {
                await this.repository.DeleteAsync(ownWomanPlace);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(ownWomanPlace);
        }
    }
}
