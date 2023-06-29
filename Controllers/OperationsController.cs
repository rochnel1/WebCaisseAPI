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
    public class OperationsController : ControllerBase
    {
        private readonly CaissesContext _context;

        public OperationsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operations>>> GetOperations()
        {
            //return await _context.Operations.ToListAsync();
            var items = from o in _context.Operations
                        join c in _context.Caisses on o.Idcaisse equals c.Idcaisse
                        join personne in _context.Personnels on o.Idpersonnel equals personne.Idpersonnel
                        join periode in _context.Periodes on o.Idperiode equals periode.Idperiode
                        join e in _context.Exercices on o.Idexercice equals e.Idexercice
                        join n in _context.Natureoperations on o.Idnatureoperation equals n.Idnatureoperation

                        select new Operations
                        {
                            Idoperation = o.Idoperation,
                            Dateoperation = o.Dateoperation,
                            Description = o.Description,
                            Montant = o.Montant,
                            Sens = o.Sens,
                            Etat = o.Etat,
                            Nbrecontrole = o.Nbrecontrole,
                            Controlerpar = o.Controlerpar,
                            Comptabilserpar = o.Comptabilserpar,
                            Datecontrole = o.Datecontrole,
                            Datecloture = o.Datecloture,
                            Datecomptabilisation = o.Datecomptabilisation,
                            Cloturepar = o.Cloturepar,
                            IdcaisseNavigation = c,
                            IdpersonnelNavigation = personne,
                            IdperiodeNavigation = periode,
                            IdexerciceNavigation = e,
                            IdnatureoperationNavigation = n,
                            

                        };

            return items.ToList();
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operations>> GetOperations(int id)
        {
            var operations = await _context.Operations.FindAsync(id);

            if (operations == null)
            {
                return NotFound();
            }

            return operations;
        }

        //Get api/Operations/{idPeriode}/{idExercice}/{idNatureOperation}
        //http://localhost:5000/api/Operations/2/3/10/1/encaissement
        [HttpGet("{idExercice}/{idPeriode}/{idNature}/{sens}")]
        public async Task<ActionResult<IEnumerable<Operations>>> FilteredOperations(int? idPeriode, int?  idExercice, int? idNature, int? sens)
        {
            string Sens;
            if (sens == 0) {
                Sens = "Encaissement";
            } 
            else
            {
                Sens = "Décaissment";
            };

            var items = from operation in _context.Operations
                        join c in _context.Exercices  on operation.Idexercice equals c.Idexercice into exercice from ec in exercice.DefaultIfEmpty()
                        join d in _context.Periodes  on operation.Idperiode equals d.Idperiode into periode from pd in periode.DefaultIfEmpty()
                        join e in _context.Natureoperations on operation.Idnatureoperation equals e.Idnatureoperation into nature from no in nature.DefaultIfEmpty()
                        join b in _context.Caisses on operation.Idcaisse equals b.Idcaisse
                        join f in _context.Personnels on operation.Idpersonnel equals f.Idpersonnel
                        where(
                              (!idPeriode.HasValue || pd.Idperiode == idPeriode) &&
                              (!idPeriode.HasValue || ec.Idexercice == idExercice) &&
                              (!idNature.HasValue || no.Idnatureoperation == idNature) &&
                             ( !sens.HasValue || operation.Sens == Sens))
            select new
                        {
                caisse = b.Codecaisse,
                caissier = f.Codepersonnel,
                date = operation.Dateoperation,
                information = operation.Description,
                montant = operation.Montant,
                exercice = ec.Code,
                periode = pd.Codeperiode,
                nature = no.Codenature,
                sens = operation.Sens,
                etat = operation.Etat
            };

            return Ok(items.ToList());
        }

        // PUT: api/Operations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperations(int id, Operations operations)
        {
            if (id != operations.Idoperation)
            {
                return BadRequest();
            }

            _context.Entry(operations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationsExists(id))
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

        // POST: api/Operations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Operations>> PostOperations(Operations operations)
        {
            _context.Operations.Add(operations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperations", new { id = operations.Idoperation }, operations);
        }

        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operations>> DeleteOperations(int id)
        {
            var operations = await _context.Operations.FindAsync(id);
            if (operations == null)
            {
                return NotFound();
            }

            _context.Operations.Remove(operations);
            await _context.SaveChangesAsync();

            return operations;
        }

        private bool OperationsExists(int id)
        {
            return _context.Operations.Any(e => e.Idoperation == id);
        }
    }
}
