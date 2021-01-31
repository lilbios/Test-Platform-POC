using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test_Platform_POC.Data.Interfaces
{
    public interface IBaseGenericRepository<TEntity> where TEntity : class
    {
        public Task<IMongoCollection<TEntity>> GetCollectionAsync();
        public Task<TEntity> AddAsync(TEntity record);
        public Task<TEntity> AddRecordsAsync(IEnumerable<TEntity> records);
        public Task<TEntity> UpdateRecordsAsync(IEnumerable<TEntity> records);
        public Task<TEntity> UpdateAsync(Guid id, TEntity record);

    }
}
