using AutoMapper;
using VodjenjeKaficaCSHARP.Models;
using VodjenjeKaficaCSHARP.Models.DTO;

namespace VodjenjeKaficaCSHARP.Mapping
{
    public class VodjenjeKaficaMappingProfile:Profile
    {

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
                
        }

    }
}
