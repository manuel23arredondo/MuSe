namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class HelpTypesController : Controller
    {
        private readonly DataContext _context;

        public HelpTypesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.HelpTypes.ToListAsync());
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
                _context.Add(helpType);
                await _context.SaveChangesAsync();
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

            var helpType = await _context.HelpTypes.FindAsync(id);
            if (helpType == null)
            {
                return NotFound();
            }
            return View(helpType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] HelpType helpType)
        {
            if (id != helpType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helpType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpTypeExists(helpType.Id))
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

            var helpType = await _context.HelpTypes
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var helpType = await _context.HelpTypes.FindAsync(id);
            _context.HelpTypes.Remove(helpType);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(helpType);
        }

        private bool HelpTypeExists(int id)
        {
            return _context.HelpTypes.Any(e => e.Id == id);
        }
    }
}
