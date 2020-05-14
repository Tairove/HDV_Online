using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HDV_Online.Models;

namespace HDV_Online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordonneesController : ControllerBase
    {
        private readonly HDVContext _context;

        public CoordonneesController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/Coordonnees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordonnee>>> GetCoordonnee()
        {
            return await _context.Coordonnee.ToListAsync();
        }

        // GET: api/Coordonnees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coordonnee>> GetCoordonnee(int id)
        {
            var coordonnee = await _context.Coordonnee.FindAsync(id);

            if (coordonnee == null)
            {
                return NotFound();
            }

            return coordonnee;
        }

        [HttpGet("client/{id}")]
        public async Task<ActionResult<IEnumerable<Coordonnee>>> GetCoordonneeByClient(int id)
        {
            return await _context.Coordonnee.Where(c => c.ClientId==id).Include(p => p.Pays).ToListAsync();

        }

        // PUT: api/Coordonnees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordonnee(int id, Coordonnee coordonnee)
        {
            if (id != coordonnee.Id)
            {
                return BadRequest();
            }

            _context.Entry(coordonnee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordonneeExists(id))
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

        // POST: api/Coordonnees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coordonnee>> PostCoordonnee(Coordonnee coordonnee)
        {
            _context.Coordonnee.Add(coordonnee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordonnee", new { id = coordonnee.Id }, coordonnee);
        }

        // DELETE: api/Coordonnees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coordonnee>> DeleteCoordonnee(int id)
        {
            var coordonnee = await _context.Coordonnee.FindAsync(id);
            if (coordonnee == null)
            {
                return NotFound();
            }

            _context.Coordonnee.Remove(coordonnee);
            await _context.SaveChangesAsync();

            return coordonnee;
        }

        private bool CoordonneeExists(int id)
        {
            return _context.Coordonnee.Any(e => e.Id == id);
        }
    }
}
