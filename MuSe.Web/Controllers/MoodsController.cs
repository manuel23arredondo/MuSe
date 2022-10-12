namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data;
    using System.Threading.Tasks;
    using System;
    using System.Linq;

    public class MoodsController : Controller
    {
        private readonly DataContext _context;

        public MoodsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Moods.ToListAsync());
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
                _context.Add(mood);
                await _context.SaveChangesAsync();
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

            var mood = await _context.Moods.FindAsync(id);
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
                    _context.Update(mood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoodsExists(mood.Id))
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

            var mood = await _context.Moods
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
            var mood = await _context.Moods.FindAsync(id);
            _context.Moods.Remove(mood);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(mood);
        }

        private bool MoodsExists(int id)
        {
            return _context.HelpTypes.Any(e => e.Id == id);
        }
    }
}
