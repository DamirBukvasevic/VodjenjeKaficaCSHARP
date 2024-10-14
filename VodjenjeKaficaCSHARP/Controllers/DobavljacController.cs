using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (!ModelState.IsValid)
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
                return NotFound(new { poruka = "Dobavljač ne postoji u bazi" });
            }
            return Ok(_mapper.Map<DobavljacDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(DobavljacDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
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
                    return NotFound(new { poruka = "Dobavljač ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Dobavljaci.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Dobavljač uspješno promjenjen" });
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
                    return NotFound(new { poruka = "Dobavljač ne postoji u bazi" });
                }
                _context.Dobavljaci.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Dobavljač uspješno obrisan" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<DobavljacDTORead>> TraziDobavljaca(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Dobavljac> query = _context.Dobavljaci;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(d => d.Naziv.ToLower().Contains(s)
                                        || d.Oib.ToLower().Contains(s)
                                        || d.Grad.ToLower().Contains(s)
                                        || d.Adresa.ToLower().Contains(s));
                }
                var dobavljaci = query.ToList();
                return Ok(_mapper.Map<List<DobavljacDTORead>>(dobavljaci));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

        [HttpGet]
        [Route("traziStranicenje/{stranica}")]
        public IActionResult TraziDobavljacStranicenje(int stranica, string uvjet = "")
        {
            var poStranici = 14;
            uvjet = uvjet.ToLower();
            try
            {
                var dobavljaci = _context.Dobavljaci
                    .Where(d => EF.Functions.Like(d.Naziv.ToLower(), "%" + uvjet + "%")
                                || EF.Functions.Like(d.Oib.ToLower(), "%" + uvjet + "%")
                                || EF.Functions.Like(d.Grad.ToLower(), "%" + uvjet + "%")
                                || EF.Functions.Like(d.Adresa.ToLower(), "%" + uvjet + "%"))
                    .Skip((poStranici * stranica) - poStranici)
                    .Take(poStranici)
                    .OrderBy(d => d.Naziv)
                    .ToList();


                return Ok(_mapper.Map<List<DobavljacDTORead>>(dobavljaci));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
