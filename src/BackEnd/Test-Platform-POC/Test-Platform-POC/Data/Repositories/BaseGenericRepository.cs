using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Platform_POC.Data.Interfaces;

namespace Test_Platform_POC.Data.Repositories
{
    public class BaseGenericRepository<TEntity> : IBaseGenericRepository<TEntity> where TEntity : class
    {

        private readonly IMongoCollection<TEntity> collection;

        public BaseGenericRepository(AppDbContext context)
        {
            collection = context.MongoDatabase.GetCollection<TEntity>(typeof(TEntity).FullName);
        }

        public async Task<TEntity> AddAsync(TEntity record)
        {
            await collection.InsertOneAsync(record);
            return record;
        }

        public Task<TEntity> AddRecordsAsync(IEnumerable<TEntity> records)
        {
            throw new NotImplementedException();
        }

        public Task<IMongoCollection<TEntity>> GetCollectionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(Guid id, TEntity _object)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateRecordsAsync(IEnumerable<TEntity> records)
        {
            throw new NotImplementedException();
        }
    }
}
