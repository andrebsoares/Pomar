using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class ArvoreRepository : RepositoryBase<Arvore>, IArvoreRepository
    {
        public ArvoreRepository(DataContext context) : base(context)
        { }
    }
}