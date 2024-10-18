namespace VodjenjeKaficaCSHARP.Models
{
    /// <summary>
    /// Dobavljač u bazi podataka.
    /// </summary>
    public class Dobavljac: Entitet
    {
        /// <summary>
        /// Naziv dobavljača.
        /// </summary>
        public string? Naziv { get; set; }
        /// <summary>
        /// Grad dobavljača.
        /// </summary>
        public string? Grad { get; set; }
        /// <summary>
        /// Adresa dobavljača.
        /// </summary>
        public string? Adresa { get; set; }
        /// <summary>
        /// OIB dobavljača
        /// </summary>
        public string? Oib { get; set; }
    }
}
