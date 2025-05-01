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
    public class FilialController : BaseController<Filial,FilialModel>
    {
        private readonly IFilialApp _filialApp;
        private readonly IMapper _mapper;
        public FilialController(IFilialApp filialApp, IMapper mapper) : base(filialApp, mapper) 
        {
            _filialApp = filialApp;
            _mapper = mapper;
        }
    }
}
