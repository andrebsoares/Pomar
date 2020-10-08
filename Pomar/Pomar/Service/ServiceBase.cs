using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomar.Service
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task Add(T obj)
        {
            await _repository.Add(obj);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _repository.Get();
        }

        public virtual async Task Remove(int id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(T obj)
        {
            await _repository.Update(obj);
        }
    }
}
