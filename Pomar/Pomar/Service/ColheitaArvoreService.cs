using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class ColheitaArvoreService : ServiceBase<ColheitaArvore>, IColheitaArvoreService
    {
        private readonly IColheitaArvoreRepository _colheitaArvoreRepository;
        public ColheitaArvoreService(IColheitaArvoreRepository repository) : base(repository)
        {
            _colheitaArvoreRepository = repository;
        }
    }
}