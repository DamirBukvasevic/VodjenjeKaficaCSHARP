using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;

namespace VodjenjeKaficaCSHARP.Controllers
{
    public abstract class VodjenjeKaficaController:ControllerBase
    {
        protected readonly VodjenjeKaficaContext _context;

        protected readonly IMapper _mapper;


        public VodjenjeKaficaController(VodjenjeKaficaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
