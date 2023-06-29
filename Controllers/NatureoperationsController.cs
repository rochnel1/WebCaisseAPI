using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCaisseAPI.Models;

namespace WebCaisseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NatureoperationsController : ControllerBase
    {
        private readonly CaissesContext _context;

        public NatureoperationsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Natureoperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Natureoperations>>> GetNatureoperations()
        {
            //return await _context.Natureoperations.ToListAsync();
            var items = await
             _context.Natureoperations.Join(
             _context.Comptegenerals,
             u => u.Idcompte,
             g => g.Idcompte,
             (u, g) => new
             {
                 u = u,
                 g = g,
             }).Select(x => new Natureoperations
             {
                 Idnatureoperation = x.u.Idnatureoperation,
                 Description = x.u.Description,
                 Typenature = x.u.Typenature,
                 Codenature = x.u.Codenature,
                 Sensnature = x.u.Sensnature,
                 IdcompteNavigation = x.g,
             }).ToListAsync();

            return items;
        }

        // GET: api/Natureoperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Natureoperations>> GetNatureoperations(int id)
        {
            var natureoperations = await _context.Natureoperations.FindAsync(id);

            if (natureoperations == null)
            {
                return NotFound();
            }

            return natureoperations;
        }

        // PUT: api/Natureoperations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNatureoperations(int id, Natureoperations natureoperations)
        {
            if (id != natureoperations.Idnatureoperation)
            {
                return BadRequest();
            }

            _context.Entry(natureoperations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NatureoperationsExists(id))
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

        // POST: api/Natureoperations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Natureoperations>> PostNatureoperations(Natureoperations natureoperations)
        {
            _context.Natureoperations.Add(natureoperations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNatureoperations", new { id = natureoperations.Idnatureoperation }, natureoperations);
        }

        // DELETE: api/Natureoperations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Natureoperations>> DeleteNatureoperations(int id)
        {
            var natureoperations = await _context.Natureoperations.FindAsync(id);
            if (natureoperations == null)
            {
                return NotFound();
            }

            _context.Natureoperations.Remove(natureoperations);
            await _context.SaveChangesAsync();

            return natureoperations;
        }

        private bool NatureoperationsExists(int id)
        {
            return _context.Natureoperations.Any(e => e.Idnatureoperation == id);
        }
    }
}
