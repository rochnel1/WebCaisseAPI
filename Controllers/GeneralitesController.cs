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
    public class GeneralitesController : ControllerBase
    {
        private readonly CaissesContext _context;

        public GeneralitesController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Generalites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Generalites>>> GetGeneralites()
        {
            return await _context.Generalites.ToListAsync();
        }

        // GET: api/Generalites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Generalites>> GetGeneralites(int id)
        {
            var generalites = await _context.Generalites.FindAsync(id);

            if (generalites == null)
            {
                return NotFound();
            }

            return generalites;
        }

        // PUT: api/Generalites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralites(int id, Generalites generalites)
        {
            if (id != generalites.Idgeneralite)
            {
                return BadRequest();
            }

            _context.Entry(generalites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralitesExists(id))
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

        // POST: api/Generalites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Generalites>> PostGeneralites(Generalites generalites)
        {
            _context.Generalites.Add(generalites);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralites", new { id = generalites.Idgeneralite }, generalites);
        }

        // DELETE: api/Generalites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Generalites>> DeleteGeneralites(int id)
        {
            var generalites = await _context.Generalites.FindAsync(id);
            if (generalites == null)
            {
                return NotFound();
            }

            _context.Generalites.Remove(generalites);
            await _context.SaveChangesAsync();

            return generalites;
        }

        private bool GeneralitesExists(int id)
        {
            return _context.Generalites.Any(e => e.Idgeneralite == id);
        }
    }
}
