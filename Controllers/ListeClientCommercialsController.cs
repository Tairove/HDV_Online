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
    public class ListeClientCommercialsController : ControllerBase
    {
        private readonly HDVContext _context;

        public ListeClientCommercialsController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/ListeClientCommercials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListeClientCommercial>>> GetListeClientCommercials()
        {
            return await _context.ListeClientCommercials.ToListAsync();
        }

        // GET: api/ListeClientCommercials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListeClientCommercial>> GetListeClientCommercial(int id)
        {
            var listeClientCommercial = await _context.ListeClientCommercials.FindAsync(id);

            if (listeClientCommercial == null)
            {
                return NotFound();
            }

            return listeClientCommercial;
        }

        // PUT: api/ListeClientCommercials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListeClientCommercial(int id, ListeClientCommercial listeClientCommercial)
        {
            if (id != listeClientCommercial.Id)
            {
                return BadRequest();
            }

            _context.Entry(listeClientCommercial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListeClientCommercialExists(id))
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

        // POST: api/ListeClientCommercials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListeClientCommercial>> PostListeClientCommercial(ListeClientCommercial listeClientCommercial)
        {
            _context.ListeClientCommercials.Add(listeClientCommercial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListeClientCommercial", new { id = listeClientCommercial.Id }, listeClientCommercial);
        }

        // DELETE: api/ListeClientCommercials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListeClientCommercial>> DeleteListeClientCommercial(int id)
        {
            var listeClientCommercial = await _context.ListeClientCommercials.FindAsync(id);
            if (listeClientCommercial == null)
            {
                return NotFound();
            }

            _context.ListeClientCommercials.Remove(listeClientCommercial);
            await _context.SaveChangesAsync();

            return listeClientCommercial;
        }

        private bool ListeClientCommercialExists(int id)
        {
            return _context.ListeClientCommercials.Any(e => e.Id == id);
        }
    }
}
