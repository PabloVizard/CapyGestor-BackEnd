using Application.Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<Usuario, UsuarioModel>
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioApp usuarioApp, IMapper mapper) : base(usuarioApp, mapper)
        {
            _usuarioApp = usuarioApp;
            _mapper = mapper;
        }
    }
}
