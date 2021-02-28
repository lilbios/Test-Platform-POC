using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IGenericRepository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeFunc = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeFunc = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);
        Task<bool> UpdateCollectionAsync(IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
        Task<bool> DeleteCollectionAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TResponse>> GetWithGroupByAsync<TResponse>(Func<TEntity, object> groupBy, Func<IGrouping<object,TEntity>, TResponse> select,
            Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
