using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class GrupoArvoreService : ServiceBase<GrupoArvore>, IGrupoArvoreService
    {
        private readonly IGrupoArvoreRepository _grupoArvoreRepository;
        public GrupoArvoreService(IGrupoArvoreRepository repository) : base(repository)
        {
            _grupoArvoreRepository = repository;
        }
    }
}