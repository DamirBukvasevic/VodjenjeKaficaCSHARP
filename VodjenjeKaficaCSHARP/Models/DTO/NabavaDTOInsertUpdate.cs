using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record NabavaDTOInsertUpdate(
        [Required(ErrorMessage = "Broj nabave obavezan")]int? BrojNabave,
        DateTime? DatumNabave,
        int? DobavljacSifra
    );
}
