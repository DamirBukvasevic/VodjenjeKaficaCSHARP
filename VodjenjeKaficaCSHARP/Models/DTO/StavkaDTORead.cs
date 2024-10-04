namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record StavkaDTORead(
        int Sifra,
        int? SifraNabave,
        int? SifraArtikla,
        int? KolicinaArtikla,
        decimal? Cijena
    );
}
