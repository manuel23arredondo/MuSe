namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = "Admin")]
    public class ReliabilitiesController : Controller
    {
        private readonly IReliabilityRepository repository;

        public ReliabilitiesController(IReliabilityRepository repository)
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
        public async Task<IActionResult> Create([Bind("Id,Description")] Reliability reliability)
        {
            if (ModelState.IsValid)
            {
                await this.repository.CreateAsync(reliability);
                return RedirectToAction(nameof(Index));
            }
            return View(reliability);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reliability = await this.repository.GetByIdAsync(id.Value);
            if (reliability == null)
            {
                return NotFound();
            }
            return View(reliability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Reliability reliability)
        {
            if (id != reliability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.repository.UpdateAsync(reliability);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repository.ExistAsync(reliability.Id))
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
            return View(reliability);
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
            var reliability = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(reliability);
            return RedirectToAction(nameof(Index));
        }
    }
}
