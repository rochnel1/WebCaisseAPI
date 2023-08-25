using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebCaisseAPI.Models;

namespace WebCaisseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly CaissesContext _context;
        private readonly IConfiguration _configuration;

        public UtilisateursController(CaissesContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        
        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateurs>>> GetUtilisateurs()
        {
            //return await _context.Utilisateurs.ToListAsync();
            var items = await (
                from u in _context.Utilisateurs
                join g in _context.Groupeutilisateurs
                on u.Idgpeutilisateur equals g.Idgpeutilisateur
                select new 
                    {
                    IdUtilisateur = u.IdUtilisateur,
                    Login = u.Login,
                    Nomutilisateur = u.Nomutilisateur,
                    Prenomutilisateur = u.Prenomutilisateur,
                    NomGroupe = g.Nomgroupe
                }
                ).ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Utilisateurs>> Login([FromBody] Utilisateurs utilisateur)
        {
            // Vérifiez les informations d'identification de l'utilisateur dans la base de données
            var user = _context.Utilisateurs.FirstOrDefault(u => u.Login == utilisateur.Login && u.Password == utilisateur.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Si l'authentification réussit, générez le jeton JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecret = _configuration["Tokens:Key"]; // Récupérez la clé secrète depuis les configurations
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Login),
                    // Vous pouvez ajouter d'autres revendications ici, si nécessaire
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Durée de validité du jeton (1 heure ici)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }


        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateurs>> GetUtilisateurs(int id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);

            if (utilisateurs == null)
            {
                return NotFound();
            }

            return utilisateurs;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateurs(int id, Utilisateurs utilisateurs)
        {
            if (id != utilisateurs.IdUtilisateur)
            {
                return BadRequest();
            }

            _context.Entry(utilisateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateursExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Utilisateurs>> PostUtilisateurs(Utilisateurs utilisateurs)
        {
            _context.Utilisateurs.Add(utilisateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Vous avez été enregistré avec succès !", new { id = utilisateurs.IdUtilisateur }, utilisateurs);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilisateurs>> DeleteUtilisateurs(int id)
        {
            var utilisateurs = await _context.Utilisateurs.FindAsync(id);
            if (utilisateurs == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateurs);
            await _context.SaveChangesAsync();

            return utilisateurs;
        }

        private bool UtilisateursExists(int id)
        {
            return _context.Utilisateurs.Any(e => e.IdUtilisateur == id);
        }
    }
}
