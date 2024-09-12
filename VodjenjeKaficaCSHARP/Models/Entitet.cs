using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }
    }
}
