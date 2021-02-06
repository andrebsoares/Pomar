using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomar.Data;
using Pomar.Interfaces.Repositories;
using Pomar.Models;

namespace Pomar.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        { }

        public async Task<User> Get(string usuario)
        {
            return await _dbSet.Where(x => x.Usuario == usuario).FirstOrDefaultAsync();
        }
    }
}