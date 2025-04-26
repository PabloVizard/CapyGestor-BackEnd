using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class UsuarioApp : BaseApp<Usuario, UsuarioModel>, IUsuarioApp
    {
        protected readonly IUsuarioService _usuarioService;
        protected readonly IMapper _mapper;

        public UsuarioApp(IUsuarioService usuarioService, IMapper mapper) : base(usuarioService, mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
    }
}
