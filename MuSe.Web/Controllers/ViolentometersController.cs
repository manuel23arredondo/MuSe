namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Threading.Tasks;
    public class ViolentometersController : Controller
    {
        private readonly ICombosHelper combosHelper;
        private readonly IViolentometerRepository repository;

        public ViolentometersController(IViolentometerRepository repository,
            ICombosHelper combosHelper)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetViolentometersWithReliabilities());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ViolentometerViewModel
            {
                Reliabilities = this.combosHelper.GetComboReliabilities()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ViolentometerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var violentometer = new Violentometer
                {
                    Description = model.Description,
                    Reliability = await this.repository.GetReliabitiesByIdAsync(model.ReliabilityId)
                };
                await this.repository.CreateAsync(violentometer);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violentometer = await this.repository.GetViolentometersWithReliabilitiesByIdAsync(id.Value);

            if (violentometer == null)
            {
                return NotFound();
            }

            var model = new ViolentometerViewModel
            {
                Description = violentometer.Description,
                Reliability = violentometer.Reliability,
                ReliabilityId = violentometer.Reliability.Id,
                Reliabilities = this.combosHelper.GetComboReliabilities()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViolentometerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var violentometer = new Violentometer
                {
                    Id = model.Id,
                    Description = model.Description,
                    Reliability = await this.repository.GetReliabitiesByIdAsync(model.ReliabilityId)
                };

                await this.repository.UpdateAsync(violentometer);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violentometer = await this.repository.GetViolentometersWithReliabilitiesByIdAsync(id.Value);

            if (violentometer == null)
            {
                return NotFound();
            }

            return View(violentometer);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violentometer = await this.repository.GetViolentometersWithReliabilitiesByIdAsync(id.Value);

            if (violentometer == null)
            {
                return NotFound();
            }
            return View(violentometer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var violentometer = await this.repository.GetViolentometersWithReliabilitiesByIdAsync(id);

            try
            {
                await this.repository.DeleteAsync(violentometer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(violentometer);
        }
    }
}
