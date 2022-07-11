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
    public class PersonasPasesController : ControllerBase
    {
        private readonly MiniCoreContext _context;

        public PersonasPasesController(MiniCoreContext context)
        {
            _context = context;
        }

        // GET: api/PersonasPases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasPase>>> GetPersonasPase()
        {
          if (_context.PersonasPases == null)
          {
              return NotFound();
          }
            return await _context.PersonasPases.ToListAsync();
        }

        // GET: api/PersonasPases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonasPase>> GetPersonasPase(int id)
        {
          if (_context.PersonasPases == null)
          {
              return NotFound();
          }
            var personasPase = await _context.PersonasPases.FindAsync(id);

            if (personasPase == null)
            {
                return NotFound();
            }

            return personasPase;
        }

        // PUT: api/PersonasPases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonasPase(int id, PersonasPase personasPase)
        {
            if (id != personasPase.Id)
            {
                return BadRequest();
            }

            _context.Entry(personasPase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasPaseExists(id))
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

        // POST: api/PersonasPases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonasPase>> PostPersonasPase(PersonasPase personasPase)
        {
          if (_context.PersonasPases == null)
          {
              return Problem("Entity set 'MiniCoreContext.PersonasPase'  is null.");
          }
            _context.PersonasPases.Add(personasPase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonasPase", new { id = personasPase.Id }, personasPase);
        }

        // DELETE: api/PersonasPases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonasPase(int id)
        {
            if (_context.PersonasPases == null)
            {
                return NotFound();
            }
            var personasPase = await _context.PersonasPases.FindAsync(id);
            if (personasPase == null)
            {
                return NotFound();
            }

            _context.PersonasPases.Remove(personasPase);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("byFecha/{date}")]
        public async Task<List<PersonasPase>> GetPersonasPaseByFecha(DateTime date)
        {
            return await _context.PersonasPases.Where(ps => ps.FechaCompra.CompareTo(date) >= 0).ToListAsync();
        }

        private bool PersonasPaseExists(int id)
        {
            return (_context.PersonasPases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
