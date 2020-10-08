using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class ColheitaRepository : RepositoryBase<Colheita>, IColheitaRepository
    {
        public ColheitaRepository(DataContext context) : base(context)
        { }
    }
}