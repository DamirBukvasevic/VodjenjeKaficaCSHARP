namespace VodjenjeKaficaCSHARP.Models.DTO
{
    /// <summary>
    /// DTO klasa koja predstavlja čitanje podataka o nabavi.
    /// </summary>
    /// <param name="Sifra">Šifra nabave</param>
    /// <param name="BrojNabave">Broj nabave</param>
    /// <param name="DatumNabave">Datum nabave</param>
    /// <param name="DobavljacNaziv">Naziv dobavljača</param>
    public record NabavaDTORead(
        int Sifra,
        int? BrojNabave,
        DateTime? DatumNabave,
        string? DobavljacNaziv
        );  
}
