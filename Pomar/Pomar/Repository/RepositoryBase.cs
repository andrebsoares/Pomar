using Microsoft.EntityFrameworkCore;
using Pomar.Data;
using Pomar.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomar.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext _data;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DataContext context)
        {
            _data = context;
            _dbSet = _data.Set<T>();
        }

        public virtual async Task Add(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _data.SaveChangesAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Remove(int id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await _data.SaveChangesAsync();
        }

        public virtual async Task Update(T obj)
        {
            _dbSet.Update(obj);
            await _data.SaveChangesAsync();
        }
    }
}
