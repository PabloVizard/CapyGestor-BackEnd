using Domain.Entities;

namespace Application.Models
{
    public class UsuarioFilialModel : BaseModel
    {
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int? FilialId { get; set; }
        public Filial? Filial { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
