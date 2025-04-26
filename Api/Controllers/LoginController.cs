using Application.Application;
using Application.Application.Interfaces;
using Application.Models;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly Settings _settings;
        public LoginController(IUsuarioApp usuarioApp, IOptions<Settings> settings)
        {
            _usuarioApp = usuarioApp;
            _settings = settings.Value;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginModel loginModel)
        {
            try
            {
                if (loginModel == null || string.IsNullOrEmpty(loginModel.login) || string.IsNullOrEmpty(loginModel.senha))
                {
                    return Unauthorized("Parametros Invalidos");
                }

                loginModel.senha = Cryptography.ConvertToSha256Hash(loginModel.senha).ToLower();

                var user = await _usuarioApp.FindByAsync(x => x.Login == loginModel.login && x.Senha == loginModel.senha);

                if (user == null)
                {
                    return Unauthorized("Usuário ou Senha Invalidos");
                }

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
    }
}
