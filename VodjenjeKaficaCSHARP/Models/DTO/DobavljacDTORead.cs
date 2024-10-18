namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// Klasa koja predstavlja podatke o dobavljaču za čitanje.
    /// </summary>
    /// <param name="Sifra">Šifra dobavljača</param>
    /// <param name="Naziv">Naziv dobavljača</param>
    /// <param name="Grad">Grad dobavljača</param>
    /// <param name="Adresa">Adresa dobavljača</param>
    /// <param name="Oib">OIB dobavljača</param>
    public record DobavljacDTORead(
        int Sifra,
        string Naziv,
        string Grad,
        string Adresa,
        string? Oib);  
}
