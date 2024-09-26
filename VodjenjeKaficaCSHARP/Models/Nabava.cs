using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Nabava:Entitet
    {
        public int? BrojNabave {  get; set; }

        [ForeignKey("Dobavljac")]
        public required Dobavljac Dobavljac { get; set; }
        public DateTime? DatumNabave { get; set; }
    }
}
