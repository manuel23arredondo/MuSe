namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System;
    using System.Threading.Tasks;
    public class DirectoriesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IHelpDirectoryRepository repository;

        public DirectoriesController(IHelpDirectoryRepository repository,
            ICombosHelper combosHelper)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
        }

        public IActionResult Map()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(this.repository.GetHelpDirectoriesWithHelpTypes());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new DirectorViewModel
            {
                HelpTypes = this.combosHelper.GetComboHelpTypes()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DirectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var helpDirectory = new HelpDirectory
                {
                    OrganizationName = model.OrganizationName,
                    PhoneNumber = model.PhoneNumber,
                    Street = model.Street,
                    InsideNumber = model.InsideNumber,
                    OutsideNumber = model.OutsideNumber,
                    Colony = model.Colony,
                    PostCode = model.PostCode,
                    Email = model.Email,
                    HelpType = await this.dataContext.HelpTypes.FindAsync(model.HelpTypeId)
                };
                this.dataContext.Add(helpDirectory);
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

            var helpDirectory = await this.dataContext.HelpDirectories
                .Include(h => h.HelpType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (helpDirectory == null)
            {
                return NotFound();
            }

            var model = new DirectorViewModel
            {
                OrganizationName = helpDirectory.OrganizationName,
                PhoneNumber = helpDirectory.PhoneNumber,
                Street = helpDirectory.Street,
                InsideNumber = helpDirectory.InsideNumber,
                OutsideNumber = helpDirectory.OutsideNumber,
                Colony = helpDirectory.Colony,
                PostCode = helpDirectory.PostCode,
                Email = helpDirectory.Email,
                HelpType = helpDirectory.HelpType,
                HelpTypeId = helpDirectory.HelpType.Id,
                HelpTypes = this.combosHelper.GetComboHelpTypes()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DirectorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var helpDirectory = new HelpDirectory
                {
                    Id = model.Id,
                    OrganizationName = model.OrganizationName,
                    PhoneNumber = model.PhoneNumber,
                    Street = model.Street,
                    InsideNumber = model.InsideNumber,
                    OutsideNumber = model.OutsideNumber,
                    Colony = model.Colony,
                    PostCode = model.PostCode,
                    Email = model.Email,
                    HelpType = await this.dataContext.HelpTypes.FindAsync(model.HelpTypeId)
                };

                this.dataContext.Update(helpDirectory);
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

            var helpDirectory = await dataContext.HelpDirectories
                .Include(h => h.HelpType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (helpDirectory == null)
            {
                return NotFound();
            }

            return View(helpDirectory);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpDirectory = await dataContext.HelpDirectories
                .Include(h => h.HelpType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (helpDirectory == null)
            {
                return NotFound();
            }
            return View(helpDirectory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpDirectory = await dataContext.HelpDirectories.FindAsync(id);
            dataContext.HelpDirectories.Remove(helpDirectory);
            try
            {
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(helpDirectory);
        }
    }
}
