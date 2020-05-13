using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HDV_Online.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace HDV_Online.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly HDVContext _context;
        private readonly JwtSettings _jwtsettings;



        public UtilisateursController(HDVContext context, IOptions<JwtSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;

        }

        [HttpPost("Login")]
        public async Task<ActionResult<Utilisateur>> Login([FromBody] Utilisateur user)
        {
            var ph = new PasswordHasher();
            var providedPassword = user.Password;

            user = await _context.Utilisateur.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            var validPassword = ph.VerifyHashedPassword(user.Password, providedPassword);

            if (user != null && validPassword == Microsoft.AspNet.Identity.PasswordVerificationResult.Success)
            {
                var role = await _context.Roles.Where(r => r.Id == user.RoleId).FirstOrDefaultAsync();
                user.AccessToken = GenerateAccessToken(user.Id, role.NomRole);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        private string GenerateAccessToken(int userId, string userRoles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId)),
                    new Claim(ClaimTypes.Role, userRoles)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // GET: api/Users
        [HttpGet("GetUserByAccessToken")]
        public async Task<ActionResult<Utilisateur>> GetUserByAccessToken([FromHeader(Name = "authorization")]string accessToken)
        {
            Utilisateur user = await GetUserFromAccessToken(accessToken.Substring(7));

            if (user != null)
            {
                return user;
            }

            return user;
        }

        private async Task<Utilisateur> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name)?.Value;

                    return await _context.Utilisateur.Include(r => r.Role).Include(c => c.Client).Where(u => u.Id == Convert.ToInt32(userId)).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new Utilisateur();
            }

            return new Utilisateur();
        }

        // GET: api/Utilisateurs
        [Authorize]
        [HttpGet]
        public String Get()
        {
            return JsonConvert.SerializeObject(_context.Utilisateur.Include(r => r.Role).ToList(), Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            var password = utilisateur.Password;
            utilisateur.RoleId = 1;

            utilisateur.Password = PasswordHasher(password);

            _context.Utilisateur.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.Id }, utilisateur);
        }

        public string PasswordHasher(string password)
        {
            var ph = new PasswordHasher();

            var hashedPassword = ph.HashPassword(password);
            return hashedPassword;
        }
        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilisateur>> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return utilisateur;
        }

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateur.Any(e => e.Id == id);
        }
    }
}
