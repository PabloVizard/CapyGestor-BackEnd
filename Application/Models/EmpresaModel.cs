using Core.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EmpresaModel : BaseModel, IRemovivel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Removido { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public int UsuarioResponsavelId { get; set; }
        public UsuarioModel? UsuarioResponsavel { get; set; }
        public ICollection<UsuarioEmpresaModel>? UsuarioEmpresas { get; set; }
    }
}
