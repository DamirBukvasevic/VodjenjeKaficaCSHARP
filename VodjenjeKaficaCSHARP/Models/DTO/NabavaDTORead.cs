namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record NabavaDTORead(
        int Sifra,
        int? BrojNabave,
        string? DobavljacNaziv,
        DateTime? DatumNabave
        );
    
}
