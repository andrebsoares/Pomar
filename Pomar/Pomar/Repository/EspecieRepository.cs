using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class EspecieRepository : RepositoryBase<Especie>, IEspecieRepository
    {
        public EspecieRepository(DataContext context) : base(context)
        { }
    }
}
