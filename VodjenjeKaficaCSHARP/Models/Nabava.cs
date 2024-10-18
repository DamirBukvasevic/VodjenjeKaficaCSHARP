using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    /// <summary>
    /// Model klasa koja predstavlja nabavu.
    /// </summary>
    public class Nabava: Entitet
    {
        /// <summary>
        /// Broj nabave.
        /// </summary>
        public int? BrojNabave { get; set; }
        /// <summary>
        /// Datum nabave.
        /// </summary>
        public DateTime? DatumNabave { get; set; }
        /// <summary>
        /// Dobavljač kojem nabava pripada.
        /// </summary>

        [ForeignKey("dobavljac")]
        public required Dobavljac Dobavljac { get; set; }
        /// <summary>
        /// Lista stavki u nabavi.
        /// </summary>
        public ICollection<Stavka>? Stavke { get; set; }
    }
}
