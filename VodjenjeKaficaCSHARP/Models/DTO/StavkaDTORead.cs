namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record StavkaDTORead(
        int Sifra,
        string? ArtiklaNaziv,
        int? KolicinaArtikla,
        decimal? Cijena
    );
}
