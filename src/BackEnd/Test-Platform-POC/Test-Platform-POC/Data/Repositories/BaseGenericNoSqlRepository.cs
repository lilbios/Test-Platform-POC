using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test_Platform_POC.Data.Interfaces;

namespace Test_Platform_POC.Data.Repositories
{
    public class BaseGenericNoSqlRepository<TEntity> : IGenericNoSqlRepository<TEntity> where TEntity : class
    {
        private bool success;
        private IMongoCollection<TEntity> _collection;

        public BaseGenericNoSqlRepository(AppDbContext context)
        {
            success = true;
            _collection = context.MongoDatabase.GetCollection<TEntity>(typeof(TEntity).FullName);
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                return success;
            }
            catch (MongoException)
            {
                return success = false;
            }
        }

        public async Task<bool> AddCollectionAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _collection.InsertManyAsync(entities);
                return success;
            }
            catch (MongoException)
            {
                return success = false;
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var deleteResult = await _collection.DeleteOneAsync(filter);
            return deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteCollectionAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var deleteResult = await _collection.DeleteManyAsync(filter);
            return deleteResult.DeletedCount > 0;
        }

        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResponse>> GetWithGroupByAsync<TResponse>(Expression<Func<TEntity, object>> groupBy = null, Expression<Func<TEntity, bool>> filter = null, Func<IMongoQueryable<TEntity>, IOrderedMongoQueryable<TEntity>> orderBy = null, int? limit = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> filter, TEntity entity)
        {
           var upd =  Builders<BsonDocument>.Update.Set("Age", 33);
            var updateResult =  await _collection.UpdateOneAsync(filter,null);
            return updateResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateCollectionAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<TEntity> entities)
        {
            var updateResult = await _collection.UpdateManyAsync(filter, null);
            return updateResult.ModifiedCount > 0;
        }
    }
}
