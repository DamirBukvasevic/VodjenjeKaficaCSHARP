using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class ArtiklController:ControllerBase
    {
        private readonly VodjenjeKaficaContext _context;

        public ArtiklController(VodjenjeKaficaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Artikli);
        }

        [HttpGet]
        [Route("{Sifra:int}")]
        public IActionResult GetBySifra(int Sifra)
        {
            return Ok(_context.Artikli.Find(Sifra));
        }

        [HttpPost]
        public IActionResult Post(Artikl artikl)
        {
            _context.Artikli.Add(artikl);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, artikl);
        }

        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, Artikl artikl)
        {
            var ArtikliIzBaze = _context.Artikli.Find(Sifra);

            ArtikliIzBaze.NazivArtikla = artikl.NazivArtikla;

            _context.Artikli.Update(ArtikliIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });
        }

        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
        {
            var ArtikliIzBaze = _context.Artikli.Find(Sifra);
            _context.Artikli.Remove(ArtikliIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });
        }
    }
}
