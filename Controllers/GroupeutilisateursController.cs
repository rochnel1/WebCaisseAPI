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
    public class GroupeutilisateursController : ControllerBase
    {
        private readonly CaissesContext _context;

        public GroupeutilisateursController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Groupeutilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groupeutilisateurs>>> GetGroupeutilisateurs()
        {
            return await _context.Groupeutilisateurs.ToListAsync();
        }

        // GET: api/Groupeutilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groupeutilisateurs>> GetGroupeutilisateurs(int id)
        {
            var groupeutilisateurs = await _context.Groupeutilisateurs.FindAsync(id);

            if (groupeutilisateurs == null)
            {
                return NotFound();
            }

            return groupeutilisateurs;
        }

        // PUT: api/Groupeutilisateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupeutilisateurs(int id, Groupeutilisateurs groupeutilisateurs)
        {
            if (id != groupeutilisateurs.Idgpeutilisateur)
            {
                return BadRequest();
            }

            _context.Entry(groupeutilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeutilisateursExists(id))
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

        // POST: api/Groupeutilisateurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Groupeutilisateurs>> PostGroupeutilisateurs(Groupeutilisateurs groupeutilisateurs)
        {
            _context.Groupeutilisateurs.Add(groupeutilisateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupeutilisateurs", new { id = groupeutilisateurs.Idgpeutilisateur }, groupeutilisateurs);
        }

        // DELETE: api/Groupeutilisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groupeutilisateurs>> DeleteGroupeutilisateurs(int id)
        {
            var groupeutilisateurs = await _context.Groupeutilisateurs.FindAsync(id);
            if (groupeutilisateurs == null)
            {
                return NotFound();
            }

            _context.Groupeutilisateurs.Remove(groupeutilisateurs);
            await _context.SaveChangesAsync();

            return groupeutilisateurs;
        }

        private bool GroupeutilisateursExists(int id)
        {
            return _context.Groupeutilisateurs.Any(e => e.Idgpeutilisateur == id);
        }
    }
}
