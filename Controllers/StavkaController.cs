using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class StavkaController:ControllerBase
    {
        private readonly VodjenjeKaficaContext _context;

        public StavkaController(VodjenjeKaficaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Stavke);
        }

        [HttpGet]
        [Route("{Sifra:int}")]
        public IActionResult GetBySifra(int Sifra)
        {
            return Ok(_context.Stavke.Find(Sifra));
        }

        [HttpPost]
        public IActionResult Post(Stavka stavka)
        {
            _context.Stavke.Add(stavka);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, stavka);
        }

        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, Stavka stavka)
        {
            var StavkeIzBaze = _context.Stavke.Find(Sifra);

            StavkeIzBaze.SifraNabave = stavka.SifraNabave;
            StavkeIzBaze.SifraArtikla = stavka.SifraArtikla;
            StavkeIzBaze.KolicinaArtikla = stavka.KolicinaArtikla;
            StavkeIzBaze.CijenaArtikla = stavka.CijenaArtikla;

            _context.Stavke.Update(StavkeIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });
        }

        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
        {
            var StavkeIzBaze = _context.Stavke.Find(Sifra);
            _context.Stavke.Remove(StavkeIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });
        }
    }
}
