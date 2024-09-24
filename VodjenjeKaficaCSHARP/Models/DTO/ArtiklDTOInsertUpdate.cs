using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record ArtiklDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv artikla obavezan")]
        string nazivArtikla
        );
}
