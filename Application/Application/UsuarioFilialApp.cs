using Application.Application.Interfaces;
using Application.Application;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application
{
    public class UsuarioFilialApp : BaseApp<UsuarioFilial, UsuarioFilialModel>, IUsuarioFilialApp
    {
        protected readonly IUsuarioFilialService _usuarioFilialService;
        protected readonly IMapper _mapper;
        public UsuarioFilialApp(IUsuarioFilialService usuarioFilialService, IMapper mapper) : base(usuarioFilialService, mapper) 
        {
            _usuarioFilialService = usuarioFilialService;
            _mapper = mapper;
        }
    }
}
