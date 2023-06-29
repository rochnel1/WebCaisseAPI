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
    public class PeriodesController : ControllerBase
    {
        private readonly CaissesContext _context;

        public PeriodesController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Periodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Periodes>>> GetPeriodes()
        {
            //return await _context.Periodes.ToListAsync();
            var items = await
                _context.Periodes.Join(
              _context.Exercices,
              u => u.Idexercice,
              g => g.Idexercice,
              (u, g) => new
              {
                  u = u,
                  g = g,
              }).Select(x => new Periodes
              {

                  Idperiode = x.u.Idperiode,
                  Codeperiode = x.u.Codeperiode,
                  Datedebut = x.u.Datedebut,
                  Datefin = x.u.Datefin,
                  IdexerciceNavigation = x.g,
              }).ToListAsync();

            return items;
        }

        // GET: api/Periodes
        [HttpGet("exercice/{id}")]
        public async Task<ActionResult<IEnumerable<Periodes>>> GetPeriodesByExercice(int id)
        {
            //return await _context.Periodes.ToListAsync();
            var items = await
                _context.Periodes.Join(
              _context.Exercices,
              u => u.Idexercice,
              g => g.Idexercice,
              (u, g) => new
              {
                  u = u,
                  g = g,
              }).Where(x => x.u.Idexercice == id )
                .Select(x => new Periodes
              {

                  Idperiode = x.u.Idperiode,
                  Codeperiode = x.u.Codeperiode,
                  Datedebut = x.u.Datedebut,
                  Datefin = x.u.Datefin,
                  IdexerciceNavigation = x.g,
              }).ToListAsync();

            return items;
        }
        // GET: api/Periodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Periodes>> GetPeriodes(int id)
        {
            var periodes = await _context.Periodes.FindAsync(id);

            if (periodes == null)
            {
                return NotFound();
            }

            return periodes;
        }


        // GET: api/Periodes/Filtrer?id=0
        /*[HttpGet("Filtrer")]
        public async Task<ActionResult<IEnumerable<IEnumerable<Periodes>>> Filtrer(int id)
        {
            var periodes = await _context.Periodes.Where(e => e.IdexerciceNavigation
            .Idexercice
            .Contains(idexercice))
            .ToListAsync();
            if (periodes == null)
            {
                return NotFound(); 
            }
            return periodes;
        }*/

        // PUT: api/Periodes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodes(int id, Periodes periodes)
        {
            if (id != periodes.Idperiode)
            {
                return BadRequest();
            }

            _context.Entry(periodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodesExists(id))
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

        // POST: api/Periodes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Periodes>> PostPeriodes(Periodes periodes)
        {
            _context.Periodes.Add(periodes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodes", new { id = periodes.Idperiode }, periodes);
        }

        // DELETE: api/Periodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Periodes>> DeletePeriodes(int id)
        {
            var periodes = await _context.Periodes.FindAsync(id);
            if (periodes == null)
            {
                return NotFound();
            }

            _context.Periodes.Remove(periodes);
            await _context.SaveChangesAsync();

            return periodes;
        }

        private bool PeriodesExists(int id)
        {
            return _context.Periodes.Any(e => e.Idperiode == id);
        }
    }
}
