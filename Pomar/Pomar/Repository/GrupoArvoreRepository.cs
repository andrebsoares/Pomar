using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class GrupoArvoreRepository : RepositoryBase<GrupoArvore>, IGrupoArvoreRepository
    {
        public GrupoArvoreRepository(DataContext context) : base(context)
        { }
    }
}