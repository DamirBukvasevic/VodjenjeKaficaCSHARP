using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Dobavljac: Entitet
    {
        public string? Naziv { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public string? Oib { get; set; }
    }
}
