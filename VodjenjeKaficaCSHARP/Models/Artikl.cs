using System.ComponentModel.DataAnnotations.Schema;

namespace VodjenjeKaficaCSHARP.Models
{
    public class Artikl: Entitet
    {
        public string? NazivArtikla { get; set; }

        public ICollection<Stavka>? Stavke { get; } = [];
    }
}
