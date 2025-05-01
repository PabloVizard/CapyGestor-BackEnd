using Application.Application;
using Application.Application.Interfaces;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioFilialController : BaseController<UsuarioFilial, UsuarioFilialModel>
    {
        private readonly IUsuarioFilialApp _usuarioFilialApp;
        private readonly IMapper _mapper;
        public UsuarioFilialController(IUsuarioFilialApp usuarioFilialApp, IMapper mapper) : base(usuarioFilialApp, mapper) 
        {
            _usuarioFilialApp = usuarioFilialApp;
            _mapper = mapper;
        }
    }
}
