namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja podatke o artiklu za čitanje.
    /// </summary>
    /// <param name="Sifra">Šifra artikla</param>
    /// <param name="NazivArtikla">Naziv artikla</param>
    public record ArtiklDTORead(
        int Sifra,
        string NazivArtikla); 
}
