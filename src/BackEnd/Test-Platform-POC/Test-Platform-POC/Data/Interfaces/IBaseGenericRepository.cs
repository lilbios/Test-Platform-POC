using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IBaseGenericRepository<TEntity> where TEntity : class
    {
        Task<IMongoCollection<TEntity>> GetCollectionAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IMongoCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> AddAsync(TEntity record);
        Task<TEntity> AddRecordsAsync(IEnumerable<TEntity> records);
        Task<TEntity> UpdateRecordsAsync(IEnumerable<TEntity> records);
        Task<TEntity> UpdateAsync(Guid id, TEntity record);
        Task RemoveAsync(Expression<Func<TEntity, bool>> filter = null);
        Task RemoveRecordsAsync(Expression<Func<TEntity, bool>> filter = null);

    }
}
