using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class DobavljacController:ControllerBase
    {
        private readonly VodjenjeKaficaContext _context;

        public DobavljacController(VodjenjeKaficaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Dobavljaci);
        }

        [HttpGet]
        [Route("{Sifra:int}")]
        public IActionResult GetBySifra(int Sifra)
        {
            return Ok(_context.Dobavljaci.Find(Sifra));
        }

        [HttpPost]
        public IActionResult Post(Dobavljac dobavljac)
        {
            _context.Dobavljaci.Add(dobavljac);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, dobavljac);
        }

        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, Dobavljac dobavljac)
        {
            var DobavljaciIzBaze = _context.Dobavljaci.Find(Sifra);

            DobavljaciIzBaze.Sifra = dobavljac.Sifra;
            DobavljaciIzBaze.Naziv = dobavljac.Naziv;
            DobavljaciIzBaze.Grad = dobavljac.Grad;
            DobavljaciIzBaze.Adresa = dobavljac.Adresa;
            DobavljaciIzBaze.Oib = dobavljac.Oib;

            _context.Dobavljaci.Update(DobavljaciIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjeno" });
        }

        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
        {
            var DobavljaciIzBaze = _context.Dobavljaci.Find(Sifra);
            _context.Dobavljaci.Remove(DobavljaciIzBaze);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });
        }
    }
}
