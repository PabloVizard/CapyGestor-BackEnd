using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string? Login { get; set; }

        public string Senha { get; set; }

        public string? Cpf { get; set; }

        public string? Telefone { get; set; }

        public UsuarioEnumerator TipoUsuario { get; set; }

        public bool Ativo { get; set; } = true;

        public bool Removido { get; set; } = false;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? UltimoAcesso { get; set; }
    }
}
