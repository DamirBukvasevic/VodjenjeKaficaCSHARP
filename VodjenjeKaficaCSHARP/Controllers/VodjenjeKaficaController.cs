using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VodjenjeKaficaCSHARP.Data;

namespace VodjenjeKaficaCSHARP.Controllers
{
    /// <summary>
    /// Apstraktna klasa koja omogućuje instancu konteksta i mapera.
    /// </summary>
    /// <param name="context">pristup podacima u MSSQL bazi</param>
    /// <param name="mapper">pristup Automaperu</param>
    [Authorize]
    public abstract class VodjenjeKaficaController(VodjenjeKaficaContext context, IMapper mapper) :ControllerBase
    {
        /// <summary>
        /// Instance VodjenjeKaficaContext
        /// </summary>
        protected readonly VodjenjeKaficaContext _context = context;

        /// <summary>
        /// Instance IMapper
        /// </summary>
        protected readonly IMapper _mapper = mapper;
    }
}
