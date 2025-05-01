using Domain.Entities;
using Domain.Repositories.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UsuarioFilialRepository : BaseRepository<UsuarioFilial>, IUsuarioFilialRepository
    {
        public UsuarioFilialRepository(DataContext dataContext) : base(dataContext) { }
    }
}
