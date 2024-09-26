using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record NabavaDTOInsertUpdate(
        [Required(ErrorMessage = "Broj nabave obavezan")] int? BrojNabave,
        [Required(ErrorMessage = "Dobavljac obavezan")] int? DobavljacSifra,
        [Required(ErrorMessage = "Datum obavezan")] DateTime? DatumNabave
        );
    
}
