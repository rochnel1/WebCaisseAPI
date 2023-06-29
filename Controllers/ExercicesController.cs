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
    public class ExercicesController : ControllerBase
    {
        private readonly CaissesContext _context;

        public ExercicesController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Exercices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercices>>> GetExercices()
        {
            return await _context.Exercices.ToListAsync();
        }

        // GET: api/Exercices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercices>> GetExercices(int id)
        {
            var exercices = await _context.Exercices.FindAsync(id);

            if (exercices == null)
            {
                return NotFound();
            }

            return exercices;
        }

        // PUT: api/Exercices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercices(int id, Exercices exercices)
        {
            if (id != exercices.Idexercice)
            {
                return BadRequest();
            }

            _context.Entry(exercices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicesExists(id))
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

        // POST: api/Exercices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Exercices>> PostExercices(Exercices exercices)
        {
            _context.Exercices.Add(exercices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercices", new { id = exercices.Idexercice }, exercices);
        }

        // DELETE: api/Exercices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercices>> DeleteExercices(int id)
        {
            var exercices = await _context.Exercices.FindAsync(id);
            if (exercices == null)
            {
                return NotFound();
            }

            _context.Exercices.Remove(exercices);
            await _context.SaveChangesAsync();

            return exercices;
        }

        private bool ExercicesExists(int id)
        {
            return _context.Exercices.Any(e => e.Idexercice == id);
        }
    }
}
