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
    public class UsuarioEmpresaController : BaseController<UsuarioEmpresa, UsuarioEmpresaModel>
    {
        private readonly IUsuarioEmpresaApp _usuarioEmpresaApp;
        private readonly IMapper _mapper;
        public UsuarioEmpresaController(IUsuarioEmpresaApp usuarioEmpresaApp, IMapper mapper) : base(usuarioEmpresaApp, mapper)
        {
            _usuarioEmpresaApp = usuarioEmpresaApp;
            _mapper = mapper;
        }
    }
}
