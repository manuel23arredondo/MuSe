namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;
    public class KindOfPlacesController : Controller
    {
        private readonly IKindOfPlaceRepository repository;

        public KindOfPlacesController(IKindOfPlaceRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetKindOfPlaceWithOwnWomanPlaces());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] KindOfPlace kindOfPlace)
        {
            if (ModelState.IsValid)
            {
                await this.repository.CreateAsync(kindOfPlace);
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfPlace);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfPlace = await this.repository.GetByIdAsync(id.Value);
            if (kindOfPlace == null)
            {
                return NotFound();
            }
            return View(kindOfPlace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] KindOfPlace kindOfPlace)
        {
            if (id != kindOfPlace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.repository.UpdateAsync(kindOfPlace);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.repository.ExistAsync(kindOfPlace.Id))
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
            return View(kindOfPlace);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfPlace = await this.repository.GetByIdAsync(id.Value);
            if (kindOfPlace == null)
            {
                return NotFound();
            }

            return View(kindOfPlace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kindOfPlace = await this.repository.GetByIdAsync(id);
            await this.repository.DeleteAsync(kindOfPlace);
            return RedirectToAction(nameof(Index));
        }
    }
}
