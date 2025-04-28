using Core.Enums;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity, IRemovivel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string? Login { get; set; }

        public string Senha { get; set; }

        public string? Cpf { get; set; }

        public string? Telefone { get; set; }

        public TipoUsuarioEnumerator TipoUsuario { get; set; } 

        public bool Ativo { get; set; } = true;

        public bool Removido { get; set; } = false;

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public DateTime? UltimoAcesso { get; set; }
        public ICollection<Empresa>? EmpresasCadastradas { get; set; }
        public ICollection<UsuarioEmpresa>? UsuarioEmpresas { get; set; }
    }
}
