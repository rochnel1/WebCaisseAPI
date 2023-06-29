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
    public class PersonnelsController : ControllerBase
    {
        private readonly CaissesContext _context;

        public PersonnelsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Personnels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personnels>>> GetPersonnels()
        {
            //return await _context.Personnels.ToListAsync();
            var items = await
             _context.Personnels.Join(
             _context.Caisses,
             u => u.Idcaisse,
             g => g.Idcaisse,
             (u, g) => new
             {
                 u = u,
                 g = g,
             }).Select(x => new Personnels
             {
                 Idpersonnel = x.u.Idpersonnel,
                 Nom = x.u.Nom,
                 Prenom = x.u.Prenom,
                 Profil = x.u.Profil,
                 Codepersonnel = x.u.Codepersonnel,
                 IdcaisseNavigation = x.g,
             }).ToListAsync();

            return items;
        }


        // GET: api/Personnels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personnels>> GetPersonnels(int id)
        {
            var personnels = await _context.Personnels.FindAsync(id);

            if (personnels == null)
            {
                return NotFound();
            }

            return personnels;
        }

        // PUT: api/Personnels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonnels(int id, Personnels personnels)
        {
            if (id != personnels.Idpersonnel)
            {
                return BadRequest();
            }

            _context.Entry(personnels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelsExists(id))
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

        // POST: api/Personnels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Personnels>> PostPersonnels(Personnels personnels)
        {
            _context.Personnels.Add(personnels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonnels", new { id = personnels.Idpersonnel }, personnels);
        }

        // DELETE: api/Personnels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personnels>> DeletePersonnels(int id)
        {
            var personnels = await _context.Personnels.FindAsync(id);
            if (personnels == null)
            {
                return NotFound();
            }

            _context.Personnels.Remove(personnels);
            await _context.SaveChangesAsync();

            return personnels;
        }

        private bool PersonnelsExists(int id)
        {
            return _context.Personnels.Any(e => e.Idpersonnel == id);
        }
    }
}
