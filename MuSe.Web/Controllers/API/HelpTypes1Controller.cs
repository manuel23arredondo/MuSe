
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuSe.Web.Data;
using MuSe.Web.Data.Entities;

namespace MuSe.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpTypes1Controller : ControllerBase
    {
        private readonly DataContext _context;

        public HelpTypes1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/HelpTypes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HelpType>>> GetHelpTypes()
        {
            return await _context.HelpTypes.ToListAsync();
        }

        // GET: api/HelpTypes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HelpType>> GetHelpType(int id)
        {
            var helpType = await _context.HelpTypes.FindAsync(id);

            if (helpType == null)
            {
                return NotFound();
            }

            return helpType;
        }

        // PUT: api/HelpTypes1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelpType(int id, HelpType helpType)
        {
            if (id != helpType.Id)
            {
                return BadRequest();
            }

            _context.Entry(helpType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HelpTypes1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HelpType>> PostHelpType(HelpType helpType)
        {
            _context.HelpTypes.Add(helpType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelpType", new { id = helpType.Id }, helpType);
        }

        // DELETE: api/HelpTypes1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HelpType>> DeleteHelpType(int id)
        {
            var helpType = await _context.HelpTypes.FindAsync(id);
            if (helpType == null)
            {
                return NotFound();
            }

            _context.HelpTypes.Remove(helpType);
            await _context.SaveChangesAsync();

            return helpType;
        }

        private bool HelpTypeExists(int id)
        {
            return _context.HelpTypes.Any(e => e.Id == id);
        }
    }
}
