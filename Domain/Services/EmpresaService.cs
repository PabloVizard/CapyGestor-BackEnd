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
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper) : base(empresaRepository, mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
    }
}
