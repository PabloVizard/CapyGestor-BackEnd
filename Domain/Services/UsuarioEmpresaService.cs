using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioEmpresaService : BaseService<UsuarioEmpresa>, IUsuarioEmpresaService
    {
        private readonly IUsuarioEmpresaRepository _usuarioEmpresaRepository;
        private readonly IMapper _mapper;
        public UsuarioEmpresaService(IUsuarioEmpresaRepository usuarioEmpresaRepository, IMapper mapper) : base(usuarioEmpresaRepository, mapper)
        {
            _usuarioEmpresaRepository = usuarioEmpresaRepository;
            _mapper = mapper;
        }
    }
}
