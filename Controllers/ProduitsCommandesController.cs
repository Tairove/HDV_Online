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
    public class ProduitsCommandesController : ControllerBase
    {
        private readonly HDVContext _context;

        public ProduitsCommandesController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/ProduitsCommandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduitsCommande>>> GetProduitsCommandes()
        {
            return await _context.ProduitsCommandes.ToListAsync();
        }

        // GET: api/ProduitsCommandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProduitsCommande>> GetProduitsCommande(int id)
        {
            var produitsCommande = await _context.ProduitsCommandes.FindAsync(id);

            if (produitsCommande == null)
            {
                return NotFound();
            }

            return produitsCommande;
        }

        // PUT: api/ProduitsCommandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduitsCommande(int id, ProduitsCommande produitsCommande)
        {
            if (id != produitsCommande.Id)
            {
                return BadRequest();
            }

            _context.Entry(produitsCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitsCommandeExists(id))
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

        // POST: api/ProduitsCommandes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProduitsCommande>> PostProduitsCommande(ProduitsCommande produitsCommande)
        {
            _context.ProduitsCommandes.Add(produitsCommande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduitsCommande", new { id = produitsCommande.Id }, produitsCommande);
        }

        // DELETE: api/ProduitsCommandes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProduitsCommande>> DeleteProduitsCommande(int id)
        {
            var produitsCommande = await _context.ProduitsCommandes.FindAsync(id);
            if (produitsCommande == null)
            {
                return NotFound();
            }

            _context.ProduitsCommandes.Remove(produitsCommande);
            await _context.SaveChangesAsync();

            return produitsCommande;
        }

        private bool ProduitsCommandeExists(int id)
        {
            return _context.ProduitsCommandes.Any(e => e.Id == id);
        }
    }
}
