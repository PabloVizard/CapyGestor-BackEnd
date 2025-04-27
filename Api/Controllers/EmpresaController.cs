using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : BaseController<Empresa, EmpresaModel>
    {
        private readonly IEmpresaApp _empresaApp;
        private readonly IMapper _mapper;
        public EmpresaController(IEmpresaApp empresaApp, IMapper mapper) : base(empresaApp, mapper)
        {
            _empresaApp = empresaApp;
            _mapper = mapper;
        }
    }
}
