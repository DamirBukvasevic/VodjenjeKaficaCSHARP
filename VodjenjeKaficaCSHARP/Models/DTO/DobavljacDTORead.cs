namespace VodjenjeKaficaCSHARP.Models.DTO
{
    public record DobavljacDTORead(
        int Sifra,
        string Naziv,
        string Grad,
        string Adresa,
        string? Oib);
    
    
}
