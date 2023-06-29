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
    public class CaissesController : ControllerBase
    {
        private readonly CaissesContext _context;

        public CaissesController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Caisses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caisses>>> GetCaisses()
        {
            //return await _context.Caisses.ToListAsync();
            var items = await
              _context.Caisses.Join(
              _context.Comptegenerals,
              u => u.Idcompte,
              g => g.Idcompte,
              (u, g) => new
              {
                  u = u,
                  g = g,
              }).Select(x => new Caisses
              {
                  Idcaisse = x.u.Idcaisse,
                  Codecaisse = x.u.Codecaisse,
                  Descriptioncaisse = x.u.Descriptioncaisse,
                  JournalComptable = x.u.JournalComptable,
                  IdcompteNavigation = x.g,
              }).ToListAsync();

            return items;
        }

   

        // GET: api/Caisses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caisses>> GetCaisses(int id)
        {
            var caisses = await _context.Caisses.FindAsync(id);

            if (caisses == null)
            {
                return NotFound();
            }

            return caisses;
        }

        // PUT: api/Caisses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaisses(int id, Caisses caisses)
        {
            if (id != caisses.Idcaisse)
            {
                return BadRequest();
            }

            _context.Entry(caisses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaissesExists(id))
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

        // POST: api/Caisses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caisses>> PostCaisses(Caisses caisses)
        {
            _context.Caisses.Add(caisses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaisses", new { id = caisses.Idcaisse }, caisses);
        }

        // DELETE: api/Caisses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caisses>> DeleteCaisses(int id)
        {
            var caisses = await _context.Caisses.FindAsync(id);
            if (caisses == null)
            {
                return NotFound();
            }

            _context.Caisses.Remove(caisses);
            await _context.SaveChangesAsync();

            return caisses;
        }

        private bool CaissesExists(int id)
        {
            return _context.Caisses.Any(e => e.Idcaisse == id);
        }
    }
}
