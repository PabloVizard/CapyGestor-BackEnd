using Application.Application;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application
{
    public class FilialApp : BaseApp<Filial, FilialModel>, IFilialApp
    {
        protected readonly IFilialService _filialService;
        protected readonly IMapper _mapper;
        public FilialApp(IFilialService filialService, IMapper mapper) : base(filialService, mapper) 
        {
            _filialService = filialService;
            _mapper = mapper;
        }
    }
}
