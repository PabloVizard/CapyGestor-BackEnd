using Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class TokenAuthentication
    {
        private static readonly IConfiguration _configuration;
        static TokenAuthentication()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static string GenerateToken(AuthModel authModel, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim("id", authModel.id.ToString()),
                new Claim("Login", authModel.login.ToString()),
                new Claim("Senha", authModel.senha.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(31),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static AuthModel GetTokenAuthModel(string token)
        {

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ReadJwtToken(token).Claims.ToArray();
                var jwtModel = new AuthModel
                {
                    id = int.Parse(claims[0].Value),
                    login = claims[1].Value,
                    senha = claims[2].Value,
                };

                return jwtModel;
            }
            catch (ArgumentException ex)
            {
                return new AuthModel();
            }

        }
    }
}
