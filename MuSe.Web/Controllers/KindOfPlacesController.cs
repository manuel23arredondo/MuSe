namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class KindOfPlacesController : Controller
    {
        private readonly DataContext _context;

        public KindOfPlacesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.KindOfPlaces.ToListAsync());
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
                _context.Add(kindOfPlace);
                await _context.SaveChangesAsync();
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

            var kindOfPlace = await _context.KindOfPlaces.FindAsync(id);
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
                    _context.Update(kindOfPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindOfPlacesExists(kindOfPlace.Id))
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

            var mood = await _context.KindOfPlaces
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var kindOfPlace = await _context.KindOfPlaces.FindAsync(id);
            _context.KindOfPlaces.Remove(kindOfPlace);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(kindOfPlace);
        }

        private bool KindOfPlacesExists(int id)
        {
            return _context.HelpTypes.Any(e => e.Id == id);
        }
    }
}
