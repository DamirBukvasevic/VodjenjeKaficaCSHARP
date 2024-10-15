using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    /// <summary>
    /// Controller for handling authorization related actions.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutorizacijaController : ControllerBase
    {
        private readonly VodjenjeKaficaContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutorizacijaController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AutorizacijaController(VodjenjeKaficaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Generates a JWT token for the given operator.
        /// </summary>
        /// <param name="operater">The operator data transfer object.</param>
        /// <returns>The generated JWT token.</returns>
        [HttpPost("token")]
        public IActionResult GenerirajToken(OperaterDTO operater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operBaza = _context.Operateri
                   .Where(p => p.Email!.Equals(operater.email))
                   .FirstOrDefault();

            if (operBaza == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, ne mogu naći operatera");
            }

            if (!BCrypt.Net.BCrypt.Verify(operater.password, operBaza.Lozinka))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, lozinka ne odgovara");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MojKljucKojijeJakoTajan i dovoljno dugačak da se može koristiti");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}
