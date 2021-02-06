using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pomar.Models;

namespace Pomar.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> Get(string usuario, string senha);
    }
}