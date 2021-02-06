using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class ArvoreService : ServiceBase<Arvore>, IArvoreService
    {
        private readonly IArvoreRepository _arvoreRepository;
        public ArvoreService(IArvoreRepository repository) : base(repository)
        {
            _arvoreRepository = repository;
        }
    }
}