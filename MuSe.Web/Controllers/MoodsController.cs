namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data;
    using System.Threading.Tasks;
    using System;
    using System.Linq;
    using MuSe.Web.Data.Repositories;

    public class MoodsController : Controller
    {
        private readonly IMoodRepository repository;

        public MoodsController(IMoodRepository repository)
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
        public async Task<IActionResult> Create([Bind("Id,Description")] Mood mood)
        {
            if (ModelState.IsValid)
            {
                await this.repository.CreateAsync(mood);
                return RedirectToAction(nameof(Index));
            }
            return View(mood);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await this.repository.GetByIdAsync(id.Value);
            if (mood == null)
            {
                return NotFound();
            }
            return View(mood);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Mood mood)
        {
            if (id != mood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.repository.UpdateAsync(mood);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repository.ExistAsync(mood.Id))
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
            return View(mood);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await this.repository.GetByIdAsync(id.Value);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mood = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(mood);
            return RedirectToAction(nameof(Index));
        }
    }
}
