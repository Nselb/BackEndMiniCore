using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCore.Data;
using MiniCore.Models;

namespace MiniCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPasesController : ControllerBase
    {
        private readonly MiniCoreContext _context;

        public TipoPasesController(MiniCoreContext context)
        {
            _context = context;
        }

        // GET: api/TipoPases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPase>>> GetTipoPase()
        {
          if (_context.TipoPases == null)
          {
              return NotFound();
          }
            return await _context.TipoPases.ToListAsync();
        }

        // GET: api/TipoPases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPase>> GetTipoPase(int id)
        {
          if (_context.TipoPases == null)
          {
              return NotFound();
          }
            var tipoPase = await _context.TipoPases.FindAsync(id);

            if (tipoPase == null)
            {
                return NotFound();
            }

            return tipoPase;
        }

        // PUT: api/TipoPases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPase(int id, TipoPase tipoPase)
        {
            if (id != tipoPase.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPaseExists(id))
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

        // POST: api/TipoPases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPase>> PostTipoPase(TipoPase tipoPase)
        {
          if (_context.TipoPases == null)
          {
              return Problem("Entity set 'MiniCoreContext.TipoPase'  is null.");
          }
            _context.TipoPases.Add(tipoPase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPase", new { id = tipoPase.Id }, tipoPase);
        }

        // DELETE: api/TipoPases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPase(int id)
        {
            if (_context.TipoPases == null)
            {
                return NotFound();
            }
            var tipoPase = await _context.TipoPases.FindAsync(id);
            if (tipoPase == null)
            {
                return NotFound();
            }

            _context.TipoPases.Remove(tipoPase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPaseExists(int id)
        {
            return (_context.TipoPases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
