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
                e = _context.Artikli.Find(Sifra);
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
        public IActionResult Post(ArtiklDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState});
            }
            try
            {
                var e = _mapper.Map<Artikl>(dto);
                _context.Artikli.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<ArtiklDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, ArtiklDTOInsertUpdate dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Artikl? e;
                try
                {
                    e = _context.Artikli.Find(Sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Artikl ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Artikli.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješna promjena podataka" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Artikl? e;
                try
                {
                    e = _context.Artikli.Find(Sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Artikl ne postoji u bazi");
                }
                _context.Artikli.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}
