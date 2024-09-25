using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezan")] string? Naziv,
        [Required(ErrorMessage = "Grad obavezan")] string? Grad,
        [Required(ErrorMessage = "Adresa obavezna")] string? Adresa,
        [Required(ErrorMessage = "Oib obavezan")] string? Oib
        ); 
}
