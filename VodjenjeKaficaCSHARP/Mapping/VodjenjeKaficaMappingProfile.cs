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

        }

    }
}
