using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioFilial : BaseEntity
    {
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int? FilialId { get; set; }
        public Filial? Filial { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }

}
