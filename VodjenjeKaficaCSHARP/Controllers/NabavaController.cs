
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NabavaController(VodjenjeKaficaContext context, IMapper mapper) : VodjenjeKaficaController(context, mapper)
    {

        [HttpGet]
        public ActionResult<List<NabavaDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<NabavaDTORead>>(_context.Nabave.Include(d => d.Dobavljac)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<NabavaDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Nabava? e;
            try
            {
                e = _context.Nabave.Include(n => n.Dobavljac).FirstOrDefault(n => n.Sifra == sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Nabava ne postoji u bazi" });
            }
            return Ok(_mapper.Map<NabavaDTOInsertUpdate>(e));
        }

        [HttpPost]
        public IActionResult Post(NabavaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Dobavljac? es;
            try
            {
                es = _context.Dobavljaci.Find(dto.DobavljacSifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (es == null)
            {
                return NotFound(new { poruka = "Dobavljač na nabavi ne postoji u bazi" });
            }

            try
            {
                var e = _mapper.Map<Nabava>(dto);
                e.Dobavljac = es;
                _context.Nabave.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<NabavaDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, NabavaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Nabava? e;
                try
                {
                    e = _context.Nabave.Include(n => n.Dobavljac).FirstOrDefault(n => n.Sifra == sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Nabava ne postoji u bazi" });
                }

                Dobavljac? es;
                try
                {
                    es = _context.Dobavljaci.Find(dto.DobavljacSifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (es == null)
                {
                    return NotFound( new { poruka = "Dobavljac na grupi ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);
                e.Dobavljac = es;
                _context.Nabave.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Nabava uspješno promjenjena" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Nabava? e;
                try
                {
                    e = _context.Nabave.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Nabava ne postoji u bazi");
                }
                _context.Nabave.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Nabava uspješno obrisana" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("Artikli/{sifraNabave:int}")]
        public ActionResult<List<StavkaDTORead>> getArtikli(int sifraNabave)
        {
            if (!ModelState.IsValid || sifraNabave <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var n = _context.Nabave
                    .Include(i => i.Stavke).ThenInclude(i=>i.Artikl).FirstOrDefault(x => x.Sifra == sifraNabave);
                if (n == null)
                {
                    return BadRequest("Ne postoji nabava s šifrom " + sifraNabave + " u bazi");
                }

                return Ok(_mapper.Map<List<StavkaDTORead>>(n.Stavke));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
        [HttpPost]
        [Route("{sifra:int}/dodaj/{polaznikSifra:int}")]
        public IActionResult DodajPolaznika(int sifra, int artiklSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 || artiklSifra <= 0)
            {
                return BadRequest("Šifra grupe ili polaznika nije dobra");
            }
            try
            {
                var nabava = _context.Nabave
                    .Include(g => g.Stavke)
                    .FirstOrDefault(g => g.Sifra == sifra);
                if (nabava == null)
                {
                    return BadRequest("Ne postoji nabava s šifrom " + sifra + " u bazi");
                }
                var artikl = _context.Stavke.Find(artiklSifra);
                if (artikl == null)
                {
                    return BadRequest("Ne postoji artikl s šifrom " + artiklSifra + " u bazi");
                }
                nabava.Stavke.Add(artikl);
                _context.Nabave.Update(nabava);
                _context.SaveChanges();
                return Ok(new
                {
                    poruka = "Artikl " + nabava.BrojNabave + " dodan na nabavu "
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }
    }
}
