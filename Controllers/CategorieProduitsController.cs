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
    public class CategorieProduitsController : ControllerBase
    {
        private readonly HDVContext _context;

        public CategorieProduitsController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/CategorieProduits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieProduit>>> GetCategorieProduits()
        {
            return await _context.CategorieProduits.Include(c => c.Produit).ToListAsync();
        }

        // GET: api/CategorieProduits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieProduit>> GetCategorieProduit(int id)
        {
            var categorieProduit = await _context.CategorieProduits.FindAsync(id);

            if (categorieProduit == null)
            {
                return NotFound();
            }

            return categorieProduit;
        }

        // PUT: api/CategorieProduits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieProduit(int id, CategorieProduit categorieProduit)
        {
            if (id != categorieProduit.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorieProduit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieProduitExists(id))
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

        // POST: api/CategorieProduits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategorieProduit>> PostCategorieProduit(CategorieProduit categorieProduit)
        {
            _context.CategorieProduits.Add(categorieProduit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieProduit", new { id = categorieProduit.Id }, categorieProduit);
        }

        // DELETE: api/CategorieProduits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieProduit>> DeleteCategorieProduit(int id)
        {
            var categorieProduit = await _context.CategorieProduits.FindAsync(id);
            if (categorieProduit == null)
            {
                return NotFound();
            }

            _context.CategorieProduits.Remove(categorieProduit);
            await _context.SaveChangesAsync();

            return categorieProduit;
        }

        private bool CategorieProduitExists(int id)
        {
            return _context.CategorieProduits.Any(e => e.Id == id);
        }
    }
}
