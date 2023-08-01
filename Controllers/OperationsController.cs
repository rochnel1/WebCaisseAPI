using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebCaisseAPI.Models;

namespace WebCaisseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly CaissesContext _context;
        private readonly ILogger _contextLogger;
                public OperationsController(CaissesContext context)
        {
            _context = context;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operations>>> GetOperations()
        {
            var items = from o in _context.Operations
                        join c in _context.Caisses on o.Idcaisse equals c.Idcaisse
                        join personne in _context.Personnels on o.Idpersonnel equals personne.Idpersonnel
                        join periode in _context.Periodes on o.Idperiode equals periode.Idperiode
                        join e in _context.Exercices on o.Idexercice equals e.Idexercice
                        join n in _context.Natureoperations on o.Idnatureoperation equals n.Idnatureoperation
                        join p in _context.Personnels on o.Controlerpar equals p.Idpersonnel

                        select new Operations
                        {
                            Idoperation = o.Idoperation,
                            Dateoperation = o.Dateoperation,
                            Description = o.Description,
                            Montant = o.Montant,
                            Sens = o.Sens,
                            Etat = o.Etat,
                            Nbrecontrole = o.Nbrecontrole,
                            Comptabilserpar = o.Comptabilserpar,
                            Datecontrole = o.Datecontrole,
                            Datecloture = o.Datecloture,
                            Datecomptabilisation = o.Datecomptabilisation,
                            Cloturepar = o.Cloturepar,
                            Controlerpar = o.Controlerpar,
                            IdcaisseNavigation = c,
                            IdpersonnelNavigation = personne,
                            IdperiodeNavigation = periode,
                            IdexerciceNavigation = e,
                            IdnatureoperationNavigation = n,
                            ControlerparNavigation = p,

                        };

            return items.ToList();
        }

        [HttpGet("Compta")]
        public async Task<ActionResult<IEnumerable<Operations>>> GetOperationsCompta()
        {
            var operations = await (from o in _context.Operations
                                    join c in _context.Caisses on o.Idcaisse equals c.Idcaisse
                                    join n in _context.Natureoperations on o.Idnatureoperation equals n.Idnatureoperation
                                    join cmp in _context.Comptegenerals on c.Idcompte equals cmp.Idcompte
                                    join cmp2 in _context.Comptegenerals on n.Idcompte equals cmp2.Idcompte
                                    where o.Etat == "CLO"

                                    select new 
                                    {
                                        Comptenature = cmp2.Numcompte,
                                        Comptecaisse = cmp.Numcompte,
                                        Libelle= o.Description,
                                        Credit = o.Montant,
                                        Debit = o.Montant,
                                        Etat = o.Etat,
                                        Sens = o.Sens,
                                        Id = o.Idoperation
                                        
                                    }).ToListAsync();
            return Ok(operations);
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

            string Sens = "";
            if (sens == 0) {
                Sens = "Encaissement";
            }
            if (sens == 1)
            {
                Sens = "Décaissment";
            }


            var items = from operation in _context.Operations
                        join c in _context.Exercices  on operation.Idexercice equals c.Idexercice into exercice from ec in exercice.DefaultIfEmpty()
                        join d in _context.Periodes  on operation.Idperiode equals d.Idperiode into periode from pd in periode.DefaultIfEmpty()
                        join e in _context.Natureoperations on operation.Idnatureoperation equals e.Idnatureoperation into nature from no in nature.DefaultIfEmpty()
                        join b in _context.Caisses on operation.Idcaisse equals b.Idcaisse
                        join f in _context.Personnels on operation.Idpersonnel equals f.Idpersonnel
                        where(
                              (idPeriode != 0 ?(pd.Idperiode == idPeriode):true) &&
                              (idExercice != 0?( ec.Idexercice == idExercice):true) &&
                              (idNature != 0 ?( no.Idnatureoperation == idNature):true) &&
                             ( sens != 2 ?( operation.Sens == Sens):true))
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

            /*var a = idPeriode;
            int b = idExercice;
            int c = idNature;
            int d = sens;*/

            var p = items;
            int i = p.Count();
            return Ok(items.ToList());
        }
        
        
        //Get api/Operations/{idcaisse}/{idpersonnel}
        //http://localhost:5000/api/Operations/2/3
        [HttpGet("{idcaisse}/{idpersonnel}")]
        public async Task<ActionResult<IEnumerable<Operations>>> GetByIdsOperations(int? idCaisse, int?  idPersonnel)
        {
             var items = from operation in _context.Operations
                        join b in _context.Caisses on operation.Idcaisse equals b.Idcaisse
                        join c in _context.Personnels on operation.Idpersonnel equals c.Idpersonnel
                        join e in _context.Natureoperations on operation.Idnatureoperation equals e.Idnatureoperation into nature from no in nature.DefaultIfEmpty()

                         where (
                              ( b.Idcaisse == idCaisse) &&
                              (c.Idpersonnel == idPersonnel))
                        select new
                        {
                caisse = b.Codecaisse,
                caissier = c.Codepersonnel,
                date = operation.Dateoperation,
                montant = operation.Montant,
                nature = no.Codenature,
                sens = operation.Sens,
                etat = operation.Etat
            };

            return Ok(items.ToList());
        }

        [HttpGet("Cloture/{idcaisse}/{idpersonnel}")]
        public async Task<ActionResult<IEnumerable<Operations>>> GetCloOperations(int? idCaisse, int? idPersonnel)
        {
            var items = from operation in _context.Operations
                        join b in _context.Caisses on operation.Idcaisse equals b.Idcaisse
                        join c in _context.Personnels on operation.Idpersonnel equals c.Idpersonnel
                        join p in _context.Personnels on operation.Controlerpar equals p.Idpersonnel

                        where (
                             (b.Idcaisse == idCaisse) &&
                             (c.Idpersonnel == idPersonnel))
                        select new
                        {
                            caisse = b.Codecaisse,
                            caissier = c.Codepersonnel,
                            date = operation.Datecontrole,
                            controlerpar = p.Codepersonnel,
                            montant = operation.Montant,
                            etat = operation.Etat
                        };

            return Ok(items.ToList());
        }

        //http://localhost:5000/api/Operations/Controle/2/2/3
        [HttpPost("Controle/{idCaisse}/{idPersonnel}/{controleur}")]
        public async Task<IActionResult> ControlOperations(int idCaisse, int idPersonnel, int controleur)
        {
            var operations = from o in _context.Operations
                             where o.Idpersonnel == idPersonnel && o.Idcaisse == idCaisse && o.Etat == "OP"
                             select o;
//            string control = Convert.ToString(controleur);
            foreach (var operation in operations)
            {
                operation.Etat = "CTRL";
                operation.Datecontrole = DateTime.Now;
                operation.Controlerpar = controleur;
            }

            _context.SaveChanges();
            
            return Ok("L'état des opérations a été mis à jour avec succès.");
        }

        [HttpPost("Cloture/{idCaisse}/{idPersonnel}")]
        public async Task<IActionResult> ClotureCaisse(int idCaisse, int idPersonnel)
        {
            var operations = from o in _context.Operations
                             where o.Idpersonnel == idPersonnel && o.Idcaisse == idCaisse && o.Etat == "CTRL"
                             select o;
            //            string control = Convert.ToString(controleur);
            foreach (var operation in operations)
            {
                operation.Etat = "CLO";
                operation.Datecloture = DateTime.Now;
            }

            _context.SaveChanges();

            return Ok("L'état des opérations a été mis à jour avec succès.");
        }

        [HttpPost("Comptabiliser")]
        public async Task<IActionResult> ComptabiliserOperations(int idCaisse, int idPersonnel)
        {
            var operations = from o in _context.Operations
                             where o.Etat == "CLO"
                             select o;
            //            string control = Convert.ToString(controleur);
            foreach (var operation in operations)
            {
                operation.Etat = "CPTA";
                operation.Datecomptabilisation = DateTime.Now;
            }

            _context.SaveChanges();

            return Ok("L'état des opérations a été mis à jour avec succès.");
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

            try
            {
                _context.Operations.Add(operations);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Opération ajoutée avec succès", new { id = operations.Idoperation }, operations);
            }
            catch (Exception ex)
            {
                // En cas d'erreur, vous pouvez logger l'erreur et retourner un message d'erreur approprié
                _contextLogger.LogError(ex, "Erreur lors de la création de l'utilisateur");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors de la création de l'utilisateur");
            }
            
        }

        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operations>> DeleteOperations(int id)
        {
            var operations = await _context.Operations.FindAsync(id);
            if (operations == null)
            {
                return NotFound("Cette données n'existe pas");
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
