using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UsuarioEmpresaModel : BaseModel
    {
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel? Empresa { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
