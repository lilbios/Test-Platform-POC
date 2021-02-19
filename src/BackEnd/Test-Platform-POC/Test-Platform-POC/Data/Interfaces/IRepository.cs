using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddCollectionAsync(IEnumerable<TEntity> entities);
    }
}
