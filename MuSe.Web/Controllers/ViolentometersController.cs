namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Threading.Tasks;
    public class ViolentometersController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        public ViolentometersController(DataContext dataContext,
            ICombosHelper combosHelper)
        {
            this.dataContext = dataContext;
            this.combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            

            return View(await this.dataContext.Violentometers
                .Include(r => r.Reliability)
                .ToListAsync());
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
                    Reliability = await this.dataContext.Reliabilities.FindAsync(model.ReliabilityId)
                };
                this.dataContext.Add(violentometer);
                await this.dataContext.SaveChangesAsync();
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

            var violentometer = await this.dataContext.Violentometers
                .Include(r => r.Reliability)
                .FirstOrDefaultAsync(p => p.Id == id);

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
                    Reliability = await this.dataContext.Reliabilities.FindAsync(model.ReliabilityId)
                };

                this.dataContext.Update(violentometer);
                await this.dataContext.SaveChangesAsync();
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

            var violentometer = await dataContext.Violentometers
                .Include(f => f.Reliability)
                .FirstOrDefaultAsync(m => m.Id == id);

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

            var violentometer = await dataContext.Violentometers
                .Include(r => r.Reliability)
                .FirstOrDefaultAsync(m => m.Id == id);

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
            var violentometer = await dataContext.Violentometers.FindAsync(id);
            dataContext.Violentometers.Remove(violentometer);
            try
            {
                await dataContext.SaveChangesAsync();
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
