using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    /// <summary>
    /// Stavka u nabavi.
    /// </summary>
    public class Stavka: Entitet
    {
        /// <summary>
        /// Šifra nabave (Broj nabave) koja pripada stavci.
        /// </summary>
        [ForeignKey("SifraNabave")]
        public required Nabava Nabava { get; set; }
        /// <summary>
        /// Šifra artikla (Naziv artikla) koja pripada stavci.
        /// </summary>
        [ForeignKey("SifraArtikla")]
        public required Artikl Artikl { get; set; }
        /// <summary>
        /// Količina artikla.
        /// </summary>
        public int? KolicinaArtikla { get; set; }
        /// <summary>
        /// Cijena artikla.
        /// </summary>
        public decimal? Cijena { get; set; }
    }
}
