using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Filial : BaseEntity, IRemovivel
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? Logo { get; set; }
        public string? CpfCnpj { get; set; }
        public string? TelefoneEmpresa { get; set; }
        public string? TelefoneResponsavel { get; set; }
        public string? Email { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Removido { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public int? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public ICollection<UsuarioFilial>? UsuarioFiliais { get; set; }

    }

}
