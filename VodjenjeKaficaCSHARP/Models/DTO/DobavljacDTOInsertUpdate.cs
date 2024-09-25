using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv dobavljača obavezan")] string? Naziv,
        [Required(ErrorMessage = "Grad dobavljača obavezan")] string? Grad,
        [Required(ErrorMessage = "Adresa dobavljača obavezna")] string? Adresa,
        [Required(ErrorMessage = "Oib dobavljača obavezan")] string? Oib
        ); 
}
