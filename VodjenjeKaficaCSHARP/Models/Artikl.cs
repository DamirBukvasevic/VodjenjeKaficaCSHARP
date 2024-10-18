namespace VodjenjeKaficaCSHARP.Models
{
    /// <summary>
    /// Artikl u bazi podataka.
    /// </summary>
    public class Artikl: Entitet
    {
        /// <summary>
        /// Naziv artikla.
        /// </summary>
        public string? NazivArtikla { get; set; }
        /// <summary>
        /// Lista stavki u nabavi.
        /// </summary>
        public ICollection<Stavka>? Stavke { get; } = [];
    }
}
