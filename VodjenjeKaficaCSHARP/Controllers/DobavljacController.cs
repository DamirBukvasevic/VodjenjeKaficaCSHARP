using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class DobavljacController(VodjenjeKaficaContext context, IMapper mapper) : VodjenjeKaficaController(context, mapper)
    {


        [HttpGet]
        public ActionResult<List<DobavljacDTORead>> Get()
        {
            if (ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<DobavljacDTORead>>(_context.Dobavljaci));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("{Sifra:int}")]
        public ActionResult<DobavljacDTORead> GetBySifra(int Sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Dobavljac? e;
            try
            {
                e = _context.Dobavljaci.Find(Sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Dobavljac ne postoji u bazi" });
            }
            return Ok(_mapper.Map<DobavljacDTORead>(e));
        }

        [HttpPost]
        public ActionResult Post(DobavljacDTOInsertUpdate dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Dobavljac>(dto);
                _context.Dobavljaci.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<DobavljacDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, DobavljacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Dobavljac? e;
                try
                {
                    e = _context.Dobavljaci.Find(Sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Dobavljac ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Dobavljaci.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
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
                Dobavljac? e;
                try
                {
                    e = _context.Dobavljaci.Find(Sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Dobavljac ne postoji u bazi" });
                }
                _context.Dobavljaci.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}
