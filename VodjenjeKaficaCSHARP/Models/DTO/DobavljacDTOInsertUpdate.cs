using System.ComponentModel.DataAnnotations;
using VodjenjeKaficaCSHARP.Validations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja podatke za unos ili ažuriranje dobavljača.
    /// </summary>
    /// <param name="Naziv">Naziv dobavljača.</param>
    /// <param name="Grad">Grad dobavljača.</param>
    /// <param name="Adresa">Adresa dobavljača.</param>
    /// <param name="Oib">OIB dobavljača.</param>
    public record DobavljacDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv dobavljaca obavezan")] string? Naziv,
        [Required(ErrorMessage = "Grad dobavljaca obavezan")] string? Grad,
        [Required(ErrorMessage = "Adresa dobavljaca obavezna")] string? Adresa,
        [OibValidator]
        [Required(ErrorMessage = "Oib dobavljaca obavezan")] string? Oib
        ); 
}
