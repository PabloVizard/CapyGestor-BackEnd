using Application.Application;
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
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly IMapper _mapper;
        private readonly Settings _settings;
        public LoginController(IUsuarioApp usuarioApp, IMapper mapper, IOptions<Settings> settings)
        {
            _usuarioApp = usuarioApp;
            _mapper = mapper;
            _settings = settings.Value;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginModel loginModel)
        {
            try
            {
                if (loginModel == null || string.IsNullOrEmpty(loginModel.Login) || string.IsNullOrEmpty(loginModel.Senha))
                {
                    return Unauthorized("Parametros Invalidos");
                }

                loginModel.Senha = Cryptography.ConvertToSha256Hash(loginModel.Senha).ToLower();

                var user = await _usuarioApp.FindByAsync(x => x.Login == loginModel.Login && x.Senha == loginModel.Senha);

                if (user == null)
                {
                    return Unauthorized("Usuário ou Senha Invalidos");
                }

                user.UltimoAcesso = DateTime.UtcNow;
                await _usuarioApp.SaveChangesAsync();

                AuthModel authModel = new AuthModel
                {
                    id = user.Id,
                    login = user.Login,
                    senha = user.Senha
                };

                var tokenJWT = TokenAuthentication.GenerateToken(authModel, _settings.SecretKey);

                return Ok(new
                {
                    data = user,
                    token = tokenJWT,
                });
            }
            catch (System.Exception)
            {
                return BadRequest("Erro Inesperado");
            }
        }


        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (usuarioModel == null || string.IsNullOrEmpty(usuarioModel.Login) || string.IsNullOrEmpty(usuarioModel.Senha))
                {
                    return BadRequest("Parâmetros inválidos");
                }

                var existingUser = await _usuarioApp.FindByAsync(x => x.Login == usuarioModel.Login || x.Email == usuarioModel.Email);
                if (existingUser != null)
                {
                    return BadRequest("Usuário já existente");
                }

                var novoUsuario = new UsuarioModel
                {
                    Nome = usuarioModel.Nome,
                    Login = usuarioModel.Login,
                    Senha = Cryptography.ConvertToSha256Hash(usuarioModel.Senha).ToLower(),
                    Email = usuarioModel.Email,
                    Telefone = usuarioModel.Telefone,
                    Cpf = usuarioModel.Cpf,
                    TipoUsuario = usuarioModel.TipoUsuario,
                    Ativo = true,
                    Removido = false,
                    DataCadastro = DateTime.UtcNow
                };
                var save = await _usuarioApp.Add(novoUsuario);

                await _usuarioApp.SaveChangesAsync();

                var usuarioBanco = (EntityEntry<Usuario>) save;

                return Ok(new
                {
                    message = "Usuário registrado com sucesso",
                    data = usuarioBanco.Entity
                });
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao registrar o usuário");
            }
        }
    }
}
