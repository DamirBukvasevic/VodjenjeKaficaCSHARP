﻿
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Data;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Controllers
{
    /// <summary>
    /// Kontroler za upravljanje nabavama.
    /// </summary>
    /// <param name="context">Pristup podacima u bazi.</param>
    /// <param name="mapper">Pristup Automaperu.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NabavaController(VodjenjeKaficaContext context, IMapper mapper) : VodjenjeKaficaController(context, mapper)
    {
        /// <summary>
        /// Dohvaća sve nabave.
        /// </summary>
        /// <returns>Popis nabava</returns>
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

        /// <summary>
        /// Dohvaća nabavu prema šifri.
        /// </summary>
        /// <param name="sifra"></param>
        /// <returns>Nabava</returns>
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

        /// <summary>
        /// Dodaje novu nabavu.
        /// </summary>
        /// <param name="dto">Podaci o nabavi</param>
        /// <returns></returns>
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

        /// <summary>
        /// Ažurira nabavu prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra nabave</param>
        /// <param name="dto">Podaci o nabavi</param>
        /// <returns></returns>
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

        /// <summary>
        /// Briše nabavu prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra nabave</param>
        /// <returns>Poruka o uspješnom brisanju</returns>
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

        /// <summary>
        /// Dohvaća artikle prema šifri nabave.
        /// </summary>
        /// <param name="sifraNabave">Šifra nabave</param>
        /// <returns>Popis artikala</returns>
        [HttpGet]
        [Route("Stavke/{sifraNabave:int}")]
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

        /// <summary>
        /// Dodaje stavku u nabavu(ArtiklNaziv,količina,cijena).
        /// </summary>
        /// <param name="dto">Stavka u nabavi(ArtiklNaziv,količina,cijena)</param>
        /// <returns>Poruka o uspješnom dodavanju stavke u nabavu</returns>
        [HttpPost]
        [Route("dodajStavku")]
        public IActionResult DodajStavku(StavkaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.SifraNabave <= 0 || dto.SifraArtikla <= 0)
            {
                return BadRequest(new { poruka = "Šifra nabave ili artikl nije dobra" });
            }
            try
            {
                var nabava = _context.Nabave
                    .Include(g => g.Stavke)
                    .FirstOrDefault(g => g.Sifra == dto.SifraNabave);
                if (nabava == null)
                {
                    return BadRequest(new { poruka = "Ne postoji nabava s šifrom " + dto.SifraNabave + " u bazi" });
                }
                var artikl = _context.Artikli.Find(dto.SifraArtikla);
                if (artikl == null)
                {
                    return BadRequest(new { poruka = "Ne postoji artikl s šifrom " + dto.SifraArtikla + " u bazi" });
                }


                var stavka = new Stavka() {Nabava = nabava, Artikl = artikl, Cijena = dto.Cijena, KolicinaArtikla = dto.KolicinaArtikla };

                nabava.Stavke.Add(stavka);
                _context.Nabave.Update(nabava);
                _context.SaveChanges();
                return Ok(new
                {
                    poruka = "Artikl " + artikl.Sifra + "Artikl dodan na nabavu "
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }

        /// <summary>
        /// Briše stavku iz nabave.
        /// </summary>
        /// <param name="sifra">Šifra stavke u nabavi.</param>
        /// <returns>HTTP status kod i poruka o uspješnom brisanju.</returns>
        [HttpDelete]
        [Route("obrisiStavka/{sifra:int}")]
        [Produces("application/json")]
        public IActionResult ObrisiStavka(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 )
            {
                return BadRequest(new { poruka = "Šifra stavke nije dobra" });
            }
            try
            {
                var stavka = _context.Stavke
                    .FirstOrDefault(g => g.Sifra ==sifra);
                if (stavka == null)
                {
                    return BadRequest(new { poruka = "Ne postoji stavka s šifrom " + stavka + " u bazi" });
                }
              


                _context.Stavke.Remove(stavka);
                _context.SaveChanges();
                return Ok(new
                {
                    poruka = "Stavka " + sifra + " obrisana iz nabave "
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća nabave prema uvjetu.
        /// </summary>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Popis nabava koji zadovoljavaju uvjet pretrage u obliku DTO objekata.</returns>
        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<NabavaDTORead>> TraziNabavu(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 1)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            uvjet = uvjet.ToString();
            try
            {
                IEnumerable<Nabava> query = _context.Nabave;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(n => n.BrojNabave.ToString().Contains(s) 
                                        || n.Dobavljac.Naziv.ToLower().Contains(s)
                                        || n.DatumNabave.ToString().Contains(s));
                }
                var nabave = query.ToList();
                return Ok(_mapper.Map<List<NabavaDTORead>>(nabave));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

        /// <summary>
        /// Traži nabave s paginacijom.
        /// </summary>
        /// <param name="stranica">Broj stranice.</param>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Popis nabava koji zadovoljavaju uvjet pretrage s paginacijom u obliku DTO objekata.</returns>
        [HttpGet]
        [Route("traziStranicenje/{stranica}")]
        public IActionResult TraziNabavuStranicenje(int stranica, string uvjet = "")
        {
            var poStranici = 14;
            uvjet = uvjet.ToLower();
            uvjet = uvjet.ToString();
            try
            {
                var nabave = _context.Nabave
                    .Include(n => n.Dobavljac)
                    .Where(n => EF.Functions.Like(n.BrojNabave.ToString(), "%" + uvjet + "%")
                            || EF.Functions.Like(n.Dobavljac.Naziv.ToLower(), "%" + uvjet + "%")
                            || EF.Functions.Like(n.DatumNabave.ToString(), "%" + uvjet + "%"))
                    .Skip((poStranici * stranica) - poStranici)
                    .Take(poStranici)
                    .OrderBy(n => n.BrojNabave)
                    .ToList();


                return Ok(_mapper.Map<List<NabavaDTORead>>(nabave));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
