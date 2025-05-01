using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UsuarioFilialService : BaseService<UsuarioFilial>, IUsuarioFilialService
    {
        private readonly IUsuarioFilialRepository _usuarioFilialRepository;
        private readonly IMapper _mapper;
        public UsuarioFilialService(IUsuarioFilialRepository usuarioFilialRepository, IMapper mapper) : base(usuarioFilialRepository, mapper) 
        {
            _usuarioFilialRepository = usuarioFilialRepository;
            _mapper = mapper;
        }
    }
}
