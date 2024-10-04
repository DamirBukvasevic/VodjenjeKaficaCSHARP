using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record StavkaDTOInsertUpdate(
        [Required(ErrorMessage = "Nabava obavezna")] int? SifraNabave,
        [Required(ErrorMessage = "Artikl obavezan")] int? SifraArtikla,
        [Required(ErrorMessage = "Količina obavezna")] int? KolicinaArtikla,
        [Required(ErrorMessage = "Cijena obavezna")] decimal? Cijena
        );
    
}
