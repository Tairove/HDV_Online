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
    public class CommandesController : ControllerBase
    {
        private readonly HDVContext _context;

        public CommandesController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await _context.Commandes.Include(c => c.Client).Include(c => c.ProduitsCommandes).ThenInclude(p => p.Produit).OrderByDescending(c => c.Id).ToListAsync();
        }

        [HttpGet("client/{id}")]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandesByClient(int id)
        {
            return await _context.Commandes.Include(c => c.ProduitsCommandes).ThenInclude(p => p.Produit).Where(c => c.ClientId==id).OrderByDescending(c => c.Id).ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }


        [HttpGet("Last")]
        public int GetLastCommandeId()
        {
            var lastCommande = _context.Commandes.OrderByDescending(c => c.Id).FirstOrDefault();
            if (lastCommande == null)
            {
                var lastCommandeNull = -1;
                return lastCommandeNull;
            }

            return lastCommande.Id;
        }


        // PUT: api/Commandes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.Id)
            {
                return BadRequest();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commandes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommande", new { id = commande.Id }, commande);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commande>> DeleteCommande(int id)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commandes.Remove(commande);
            await _context.SaveChangesAsync();

            return commande;
        }

        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }
    }
}
