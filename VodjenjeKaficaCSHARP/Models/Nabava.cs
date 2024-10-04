using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Nabava: Entitet
    {
        public int? BrojNabave { get; set; }
        public DateTime? DatumNabave { get; set; }

        [ForeignKey("dobavljac")]
        public required Dobavljac Dobavljac { get; set; }

        public ICollection<Artikl>? Artikli { get; set; }
    }
}
