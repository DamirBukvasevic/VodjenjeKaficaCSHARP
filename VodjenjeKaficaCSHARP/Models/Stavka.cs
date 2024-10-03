using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Stavka: Entitet
    {
        [ForeignKey("SifraNabave")]
        public required Nabava Nabava { get; set; }
        [ForeignKey("SifraArtikla")]
        public required Artikl Artikl { get; set; }
        public int? KolicinaArtikla { get; set; }
        public decimal? Cijena { get; set; }
    }
}
