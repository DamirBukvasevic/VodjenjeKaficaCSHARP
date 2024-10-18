using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    /// <summary>
    /// Kontroler za upravljanjem artiklima.
    /// </summary>
    /// <param name="context">Pristup podacima u bazi.</param>
    /// <param name="mapper">Pristup Automaperu.</param>
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class ArtiklController(VodjenjeKaficaContext context, IMapper mapper) : VodjenjeKaficaController(context, mapper)
    {
        
        /// <summary>
        /// Dohvaća sve artikle.
        /// </summary>
        /// <returns>Popis artikala u obliku DTO objekata.</returns>
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

        /// <summary>
        /// Dohvaća artikle prema šifri.
        /// </summary>
        /// <param name="Sifra">Šifra artikla.</param>
        /// <returns>Artikl u obliku DTO objekta.</returns>
        [HttpGet]
        [Route("{Sifra:int}")]
        public ActionResult<ArtiklDTORead> GetBySifra(int Sifra)
        {
            if (!ModelState.IsValid)
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

        /// <summary>
        /// Dodaje novi artikla.
        /// </summary>
        /// <param name="dto">Podaci o artiklu za unos</param>
        /// <returns>HTTP status kod i dodani artikl u obliku DTO objekta.</returns>
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

        /// <summary>
        /// Ažurira artikl prema šifri.
        /// </summary>
        /// <param name="Sifra">Šifra artikla.</param>
        /// <param name="dto">Podaci o artiklu za ažuriranje.</param>
        /// <returns>HTTP status kod i poruka o uspješnom ažuriranju.</returns>
        [HttpPut]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int Sifra, ArtiklDTOInsertUpdate dto)
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
                    return NotFound(new { poruka = "Artikl ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Artikli.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Artikl uspješno promjenjen" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Briše artikl prema šifri.
        /// </summary>
        /// <param name="Sifra">Šifra artikla.</param>
        /// <returns>HTTP status kod i poruka o uspješnom brisanju.</returns>
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
                return Ok(new { poruka = "Artikl uspješno obrisan"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Traži artikle prema uvjetu.
        /// </summary>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Popis artikala koji zadovoljavaju uvjet pretrage u obliku DTO objekata.</returns>
        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<ArtiklDTORead>> TraziArtikl(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Artikl> query = _context.Artikli;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(a => a.NazivArtikla.ToLower().Contains(s));
                }
                var artikli = query.ToList();
                return Ok(_mapper.Map<List<ArtiklDTORead>>(artikli));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

        /// <summary>
        /// Traži artikle s paginacijom.
        /// </summary>
        /// <param name="stranica">Broj stranice.</param>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Popis artikala koji zadovoljavaju uvjet pretrage s paginacijom u obliku DTO objekata.</returns>
        [HttpGet]
        [Route("traziStranicenje/{stranica}")]
        public IActionResult TraziArtiklStranicenje(int stranica, string uvjet = "")
        {
            var poStranici = 14;
            uvjet = uvjet.ToLower();
            try
            {
                var artikli = _context.Artikli
                    .Where(a => EF.Functions.Like(a.NazivArtikla.ToLower(), "%" + uvjet + "%"))
                    .Skip((poStranici * stranica) - poStranici)
                    .Take(poStranici)
                    .OrderBy(a => a.NazivArtikla)
                    .ToList();


                return Ok(_mapper.Map<List<ArtiklDTORead>>(artikli));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
