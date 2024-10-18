using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja podatke za unos ili ažuriranje artikla.
    /// </summary>
    /// <param name="NazivArtikla">Naziv artikla.</param>
    public record ArtiklDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv artikla obavezan")]string NazivArtikla
        );
}
