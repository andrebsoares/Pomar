using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pomar.Models;

namespace Pomar.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Get(string usuario);
    }
}