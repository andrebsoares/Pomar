using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class ColheitaArvoreRepository : RepositoryBase<ColheitaArvore>, IColheitaArvoreRepository
    {
        public ColheitaArvoreRepository(DataContext context) : base(context)
        { }
    }
}