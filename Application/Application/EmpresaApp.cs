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
    public class EmpresaApp : BaseApp<Empresa, EmpresaModel>, IEmpresaApp
    {
        protected readonly IEmpresaService _empresaService;
        protected readonly IMapper _mapper;

        public EmpresaApp(IEmpresaService empresaService, IMapper mapper) : base(empresaService, mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }
    }
}
