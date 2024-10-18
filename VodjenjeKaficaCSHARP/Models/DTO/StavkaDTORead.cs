namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// DTO klasa koja predstavlja čitanje podataka o stavci.
    /// </summary>
    /// <param name="Sifra">Šifra stavke</param>
    /// <param name="ArtiklaNaziv">Naziv artikla</param>
    /// <param name="KolicinaArtikla">Količina artikla</param>
    /// <param name="Cijena">Cijena artikla</param>
    public record StavkaDTORead(
        int Sifra,
        string? ArtiklaNaziv,
        int? KolicinaArtikla,
        decimal? Cijena
    );
}
