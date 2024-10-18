using System.ComponentModel.DataAnnotations;

namespace VodjenjeKaficaCSHARP.Models
{
    /// <summary>
    /// Apstraktna klasa koja predstavlja entitet.
    /// </summary>
    public abstract class Entitet
    {
        /// <summary>
        /// Jedinstveni identifikator entiteta.
        /// </summary>
        [Key]
        public int Sifra { get; set; }
    }
}
