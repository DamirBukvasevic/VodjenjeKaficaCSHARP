using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja DTO (Data Transfer Object) za unos i ažuriranje stavke nabave.
    /// </summary>
    /// <param name="SifraNabave">Šifra nabave</param>
    /// <param name="SifraArtikla">Šifra artikla</param>
    /// <param name="KolicinaArtikla">Količina artikla</param>
    /// <param name="Cijena">Cijena artikla</param>
    public record StavkaDTOInsertUpdate(
        [Required(ErrorMessage = "Nabava obavezna")] int? SifraNabave,
        [Required(ErrorMessage = "Artikl obavezan")] int? SifraArtikla,
        [Required(ErrorMessage = "Količina obavezna")] int? KolicinaArtikla,
        [Required(ErrorMessage = "Cijena obavezna")] decimal? Cijena
        );  
}
