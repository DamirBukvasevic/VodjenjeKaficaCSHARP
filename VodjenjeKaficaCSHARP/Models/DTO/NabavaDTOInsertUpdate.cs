using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja podatke za unos ili ažuriranje nabave.
    /// </summary>
    /// <param name="BrojNabave">Broj nabave</param>
    /// <param name="DatumNabave">Datum nabave</param>
    /// <param name="DobavljacSifra">Šifra dobavljača</param>
    public record NabavaDTOInsertUpdate(
        [Required(ErrorMessage = "Broj nabave obavezan")]int? BrojNabave,
        DateTime? DatumNabave,
        int? DobavljacSifra
    );
}
