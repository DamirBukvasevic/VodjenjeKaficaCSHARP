using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;

namespace VodjenjeKaficaCSHARP.Controllers
{
    [Authorize]
    public abstract class VodjenjeKaficaController(VodjenjeKaficaContext context, IMapper mapper) :ControllerBase
    {
        protected readonly VodjenjeKaficaContext _context = context;

        protected readonly IMapper _mapper = mapper;
    }
}
