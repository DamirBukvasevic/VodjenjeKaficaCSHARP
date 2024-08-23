using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Stavka: Entitet
    {
        public int? SifraNabave { get; set; }
        public int? SifraArtikla { get; set; }
        public int? KolicinaArtikla { get; set; }
        public decimal? CijenaArtikla { get; set; }
    }
}
