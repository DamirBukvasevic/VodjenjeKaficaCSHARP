namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record NabavaDTORead(
        int Sifra,
        int? BrojNabave,
        DateTime? DatumNabave,
        string? DobavljacNaziv
        );
    
    
}
