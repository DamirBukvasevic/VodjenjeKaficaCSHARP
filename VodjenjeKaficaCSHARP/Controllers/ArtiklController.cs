using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class ArtiklController(VodjenjeKaficaContext context, IMapper mapper) : VodjenjeKaficaController(context, mapper)
    {
  
        [HttpGet]
        public ActionResult<List<ArtiklDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<ArtiklDTORead>>(_context.Artikli));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{Sifra:int}")]
        public ActionResult<ArtiklDTORead> GetBySifra(int Sifra)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState } );
            }
            Artikl? e;
            try
            {
                e = _context.Artikli.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Artikl ne postoji u bazi" });
            }
            return Ok(_mapper.Map<ArtiklDTORead>(e));

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
