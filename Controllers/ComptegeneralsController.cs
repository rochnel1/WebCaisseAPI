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
    public class ComptegeneralsController : ControllerBase
    {
        private readonly CaissesContext _context;

        public ComptegeneralsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Comptegenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comptegenerals>>> GetComptegenerals()
        {
            return await _context.Comptegenerals.ToListAsync();
        }

        // GET: api/Comptegenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comptegenerals>> GetComptegenerals(int id)
        {
            var comptegenerals = await _context.Comptegenerals.FindAsync(id);

            if (comptegenerals == null)
            {
                return NotFound();
            }

            return comptegenerals;
        }

        // PUT: api/Comptegenerals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComptegenerals(int id, Comptegenerals comptegenerals)
        {
            if (id != comptegenerals.Idcompte)
            {
                return BadRequest();
            }

            _context.Entry(comptegenerals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComptegeneralsExists(id))
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

        // POST: api/Comptegenerals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comptegenerals>> PostComptegenerals(Comptegenerals comptegenerals)
        {
            _context.Comptegenerals.Add(comptegenerals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComptegenerals", new { id = comptegenerals.Idcompte }, comptegenerals);
        }

        // DELETE: api/Comptegenerals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comptegenerals>> DeleteComptegenerals(int id)
        {
            var comptegenerals = await _context.Comptegenerals.FindAsync(id);
            if (comptegenerals == null)
            {
                return NotFound();
            }

            _context.Comptegenerals.Remove(comptegenerals);
            await _context.SaveChangesAsync();

            return comptegenerals;
        }

        private bool ComptegeneralsExists(int id)
        {
            return _context.Comptegenerals.Any(e => e.Idcompte == id);
        }
    }
}
