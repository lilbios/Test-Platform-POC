using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IGenericNoSqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetCollectionAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null);
        Task<bool> UpdateCollectionAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> filter, TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> DeleteCollectionAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TResponse>> GetWithGroupByAsync<TResponse>(Expression<Func<TEntity, object>> groupBy = null,
            Expression<Func<TEntity, bool>> filter = null, Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null, 
            int? limit = null);

    }
}
