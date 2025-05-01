using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class FilialService : BaseService<Filial>, IFilialService
    {
        private readonly IFilialRepository _filialRepository;
        private readonly IMapper _mapper;
        public FilialService(IFilialRepository filialRepository, IMapper mapper) : base(filialRepository, mapper) 
        {
            _filialRepository = filialRepository;
            _mapper = mapper;
        }
    }
}
