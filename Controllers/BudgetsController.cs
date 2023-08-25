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
    public class BudgetsController : ControllerBase
    {
        private readonly CaissesContext _context;

        public BudgetsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budgets>>> GetBudgets()
        {
           var items = from b in _context.Budgets
                        join n in _context.Natureoperations on b.Idnatureoperation equals n.Idnatureoperation
                        join p in _context.Periodes on b.Idperiode equals p.Idperiode
                        join e in _context.Exercices on b.Idexercice equals e.Idexercice
                        select new Budgets
                        {
                            Idbudget = b.Idbudget,
                            IdnatureoperationNavigation = n,
                            IdexerciceNavigation = e,
                            IdperiodeNavigation = p,
                            Realisation = b.Realisation,
                            Pourcentage = b.Pourcentage,
                            Ecart = b.Ecart,
                            Montantbudget = b.Montantbudget,
                            Sensbudget = b.Sensbudget,
                        };

            return items.ToList();
        }

        //Get api/Budgets/realisations
        [HttpGet("realisations")]
        public async Task<ActionResult<IEnumerable<Periodes>>> GetBudgetRealise(int id)
        {
            var items = (
                from a in (from op in _context.Operations
                           group op by new { op.Idexercice, op.Idperiode, op.Idnatureoperation } into grp
                           select new
                           {
                               Idexercice = grp.Key.Idexercice,
                               Idperiode = grp.Key.Idperiode,
                               Idnatureoperation = grp.Key.Idnatureoperation,
                               Montant = grp.Sum(op => op.Montant)
                           }
                           )
                join b in _context.Budgets on new { a.Idexercice, a.Idnatureoperation, a.Idperiode } equals new { b.Idexercice, b.Idnatureoperation, b.Idperiode } into b_join
                from b_joinResult in b_join.DefaultIfEmpty()
                join c in _context.Exercices on a.Idexercice equals c.Idexercice
                join d in _context.Periodes on a.Idperiode equals d.Idperiode
                join e in _context.Natureoperations on a.Idnatureoperation equals e.Idnatureoperation
                select new
                {
                    exercice = c.Code,
                    periode = d.Codeperiode,
                    nature = e.Codenature,
                    prevision = b_joinResult.Montantbudget,
                    realisation = a.Montant,
                    ecart = b_joinResult.Montantbudget - a.Montant,
                }
                ).ToList();

            return Ok(items);
        }

        //Get api/Budgets/realisations/{idPeriode}/{idExercice}/{idNatureOperation}
        [HttpGet("realisations/{idExercice}/{idPeriode}/{idNatureOperation}")]
        public async Task<ActionResult<IEnumerable<Periodes>>> GetBudgetRealiseByFilter(int idPeriode, int idExercice, int idNatureOperation)
        {

            var items = (
                from a in (from op in _context.Operations
                           group op by new { op.Idexercice, op.Idperiode, op.Idnatureoperation } into grp
                           select new
                           {
                               Idexercice = grp.Key.Idexercice,
                               Idperiode = grp.Key.Idperiode,
                               Idnatureoperation = grp.Key.Idnatureoperation,
                               Montant = grp.Sum(op => op.Montant)
                           }
                 )
                join b in _context.Budgets on new { a.Idexercice, a.Idnatureoperation, a.Idperiode } equals new { b.Idexercice, b.Idnatureoperation, b.Idperiode } into b_join
                from b_joinResult in b_join.DefaultIfEmpty()
                join c in _context.Exercices on a.Idexercice equals c.Idexercice into exercice from ec in exercice.DefaultIfEmpty()
                join d in _context.Periodes on a.Idperiode equals d.Idperiode into periode from pd in periode.DefaultIfEmpty()
                join e in _context.Natureoperations on a.Idnatureoperation equals e.Idnatureoperation into nature from no in nature.DefaultIfEmpty()
                where (
                 (idPeriode != 0 ? (pd.Idperiode == idPeriode) : true) &&
                              (idExercice != 0 ? (ec.Idexercice == idExercice) : true) &&
                              (idNatureOperation != 0 ? (no.Idnatureoperation == idNatureOperation) : true)
                )
                select new
                {
                    exercice = ec.Code,
                    periode = pd.Codeperiode,
                    nature = no.Codenature,
                    prevision = b_joinResult.Montantbudget,
                    realisation = a.Montant,
                    ecart = no.Sensnature == 1 ?  b_joinResult.Montantbudget - a.Montant : (no.Sensnature == 2 ? a.Montant - b_joinResult.Montantbudget : 0),
                }).ToList();

            return Ok(items);
        }
        

        // GET: api/Budgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Budgets>> GetBudgets(int id)
        {
            var budgets = await _context.Budgets.FindAsync(id);

            if (budgets == null)
            {
                return NotFound();
            }

            return budgets;
        }

        // PUT: api/Budgets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgets(int id, Budgets budgets)
        {
            if (id != budgets.Idbudget)
            {
                return BadRequest();
            }

            _context.Entry(budgets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetsExists(id))
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

        // POST: api/Budgets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Budgets>> PostBudgets(Budgets budgets)
        {
            _context.Budgets.Add(budgets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgets", new { id = budgets.Idbudget }, budgets);
        }

        // DELETE: api/Budgets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Budgets>> DeleteBudgets(int id)
        {
            var budgets = await _context.Budgets.FindAsync(id);
            if (budgets == null)
            {
                return NotFound();
            }

            _context.Budgets.Remove(budgets);
            await _context.SaveChangesAsync();

            return budgets;
        }

        private bool BudgetsExists(int id)
        {
            return _context.Budgets.Any(e => e.Idbudget == id);
        }
    }
}
