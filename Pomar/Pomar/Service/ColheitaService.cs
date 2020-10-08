using System;
using System.Threading.Tasks;
using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class ColheitaService : ServiceBase<Colheita>, IColheitaService
    {
        private readonly IColheitaRepository _colheitarepository;
        public ColheitaService(IColheitaRepository repository) : base(repository)
        {
            _colheitarepository = repository;
        }        
    }
}