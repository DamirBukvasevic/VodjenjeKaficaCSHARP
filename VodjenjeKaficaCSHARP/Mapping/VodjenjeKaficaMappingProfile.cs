using AutoMapper;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Mapping
{
    /// <summary>
    /// Klasa koja sadrži mapiranja između modela i DTO objekata.
    /// </summary>
    public class VodjenjeKaficaMappingProfile:Profile
    {
        /// <summary>
        /// Konstruktor koji definira mapiranja između modela i DTO objekata.
        /// </summary>
        public VodjenjeKaficaMappingProfile()
        {
            CreateMap<Artikl, ArtiklDTORead>();
            CreateMap<ArtiklDTOInsertUpdate, Artikl>();

            CreateMap<Dobavljac, DobavljacDTORead>();
            CreateMap<DobavljacDTOInsertUpdate, Dobavljac>();

            CreateMap<Nabava, NabavaDTORead>()
                .ForMember(
                    dest => dest.DobavljacNaziv,
                    opt => opt.MapFrom(src => src.Dobavljac.Naziv)
                );
            CreateMap<Nabava, NabavaDTOInsertUpdate>().ForMember(
                dest => dest.DobavljacSifra,
                opt => opt.MapFrom(src => src.Dobavljac.Sifra)
                );
            CreateMap<NabavaDTOInsertUpdate, Nabava>();
            /*
            CreateMap<Stavka, StavkaDTORead>().ForCtorParam("ArtiklaNaziv",
                opt => opt.MapFrom(src => src.Artikl.NazivArtikla)
                ).ForCtorParam("SifraNabave",
                opt => opt.MapFrom(src => src.Nabava.Sifra)
                );
            */
            CreateMap<Stavka, StavkaDTORead>().ConstructUsing(e => 
               new StavkaDTORead(e.Sifra,e.Artikl.NazivArtikla,e.KolicinaArtikla, e.Cijena)
            );
        }

    }
}
