using AutoMapper;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<NabavaDTOInsertUpdate> GetBySifra(int Sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Nabava? e;
            try
            {
                e = _context.Nabave.Include(d => d.Dobavljac).FirstOrDefault(d => d.Sifra == Sifra);
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
                return NotFound(new { poruka = "Dobavlja� na nabavi ne postoji u bazi" });
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
        public IActionResult Put(int Sifra, NabavaDTOInsertUpdate dto)
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
                    e = _context.Nabave.Include(g => g.Dobavljac).FirstOrDefault(d => d.Sifra == Sifra);
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
                    return NotFound(new { poruka = "Dobavlja� na nabavi ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);
                e.Dobavljac = es;
                _context.Nabave.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Nabava uspje�no promjenjena" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }


        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
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
                    e = _context.Nabave.Find(Sifra);
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
                return Ok(new { poruka = "Nabava uspje�no obrisana" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}