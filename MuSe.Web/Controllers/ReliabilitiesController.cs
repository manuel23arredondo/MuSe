namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class ReliabilitiesController : Controller
    {
        private readonly DataContext _context;

        public ReliabilitiesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reliabilities.ToListAsync());
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
                _context.Add(reliability);
                await _context.SaveChangesAsync();
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

            var reliability = await _context.Reliabilities.FindAsync(id);
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
                    _context.Update(reliability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReliabilityExists(reliability.Id))
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

            var mood = await _context.Reliabilities
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
            var reliability = await _context.Reliabilities.FindAsync(id);
            _context.Reliabilities.Remove(reliability);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(reliability);
        }

        private bool ReliabilityExists(int id)
        {
            return _context.HelpTypes.Any(e => e.Id == id);
        }
    }
}
