using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa : BaseEntity, IRemovivel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Removido { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public int? UsuarioResponsavelId { get; set; }
        public Usuario? UsuarioResponsavel{ get; set; }
        public ICollection<UsuarioEmpresa>? UsuarioEmpresas { get; set; }
        public ICollection<Filial>? Filiais { get; set; } 

    }
}
