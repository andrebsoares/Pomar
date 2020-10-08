using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomar.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task Add(T obj);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Update(T obj);
        Task Remove(int id);
    }
}
