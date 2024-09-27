using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv dobavljaca obavezan")] string? Naziv,
        [Required(ErrorMessage = "Grad dobavljaca obavezan")] string? Grad,
        [Required(ErrorMessage = "Adresa dobavljaca obavezna")] string? Adresa,
        [Required(ErrorMessage = "Oib dobavljaca obavezan")] string? Oib
        ); 
}
