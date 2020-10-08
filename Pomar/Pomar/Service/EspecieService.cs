using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class EspecieService : ServiceBase<Especie>, IEspecieService
    {
        private readonly IEspecieRepository _especieRepository;
        public EspecieService(IEspecieRepository repository) : base(repository)
        {
            _especieRepository = repository;
        }
    }
}
