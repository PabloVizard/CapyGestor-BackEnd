using Domain.Entities;
using Domain.Repositories.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class FilialRepository : BaseRepository<Filial>, IFilialRepository
    {
        public FilialRepository(DataContext dataContext) : base(dataContext) { }
    }
}
