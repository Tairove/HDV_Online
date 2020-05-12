using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HDV_Online.Models;
using Newtonsoft.Json;

namespace HDV_Online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeContactsController : ControllerBase
    {
        private readonly HDVContext _context;

        public TypeContactsController(HDVContext context)
        {
            _context = context;
        }

        // GET: api/TypeContacts
        [HttpGet]
        public String Get()
        {
            return JsonConvert.SerializeObject(_context.TypeContacts.ToList(), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET: api/TypeContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeContact>> GetTypeContact(int id)
        {
            var typeContact = await _context.TypeContacts.FindAsync(id);

            if (typeContact == null)
            {
                return NotFound();
            }

            return typeContact;
        }

        // PUT: api/TypeContacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeContact(int id, TypeContact typeContact)
        {
            if (id != typeContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeContactExists(id))
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

        // POST: api/TypeContacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeContact>> PostTypeContact(TypeContact typeContact)
        {
            _context.TypeContacts.Add(typeContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeContact", new { id = typeContact.Id }, typeContact);
        }

        // DELETE: api/TypeContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeContact>> DeleteTypeContact(int id)
        {
            var typeContact = await _context.TypeContacts.FindAsync(id);
            if (typeContact == null)
            {
                return NotFound();
            }

            _context.TypeContacts.Remove(typeContact);
            await _context.SaveChangesAsync();

            return typeContact;
        }

        private bool TypeContactExists(int id)
        {
            return _context.TypeContacts.Any(e => e.Id == id);
        }
    }
}
