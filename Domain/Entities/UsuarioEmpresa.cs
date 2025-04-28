using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioEmpresa : BaseEntity
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
