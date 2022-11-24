namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System;
    using System.Threading.Tasks;

    [Authorize(Roles = "Admin")]
    public class HelpTypesController : Controller
    {
        private readonly IHelpTypeRepository repository;

        public HelpTypesController(IHelpTypeRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] HelpType helpType)
        {
            if (ModelState.IsValid)
            {
                await this.repository.CreateAsync(helpType);
                return RedirectToAction(nameof(Index));
            }
            return View(helpType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpType = await this.repository.GetByIdAsync(id.Value);
            if (helpType == null)
            {
                return NotFound();
            }
            return View(helpType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HelpType helpType)
        {
            if (id != helpType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.repository.UpdateAsync(helpType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repository.ExistAsync(helpType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(helpType);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpType = await this.repository.GetByIdAsync(id.Value);
            if (helpType == null)
            {
                return NotFound();
            }

            return View(helpType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpType = await this.repository.GetByIdAsync(id);

            try
            {
                await this.repository.DeleteAsync(helpType);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(helpType);
        }
    }
}
