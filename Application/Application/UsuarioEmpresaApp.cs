using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class UsuarioEmpresaApp : BaseApp<UsuarioEmpresa, UsuarioEmpresaModel>, IUsuarioEmpresaApp
    {
        protected readonly IUsuarioEmpresaService _usuarioEmpresaService;
        protected readonly IMapper _mapper;

        public UsuarioEmpresaApp(IUsuarioEmpresaService usuarioEmpresaService, IMapper mapper) : base(usuarioEmpresaService, mapper)
        {
            _usuarioEmpresaService = usuarioEmpresaService;
            _mapper = mapper;
        }
    }
}
