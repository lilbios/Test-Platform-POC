using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test_Platform_POC.Data.Interfaces;

namespace Test_Platform_POC.Data.Repositories
{
    public class BaseGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> dbSet;
        private DbContext dbContext;

        public BaseGenericRepository(AppDbContext context)
        {
            dbSet = context.Set<TEntity>();
            dbContext = context;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> AddCollectionAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            await dbSet.SingleDeleteAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(object id)
        {
            TEntity entity = await dbSet.FindAsync(Guid.Parse(id.ToString()));

            if (entity != null)
            {
                return await DeleteAsync(entity);
            }
            return false;
        }

        public async Task<bool> DeleteCollectionAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeFunc = null, 
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> _dbSet = dbSet.AsQueryable();

            if (skip.HasValue)
            {
                _dbSet = _dbSet.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                _dbSet = _dbSet.Take(take.Value);
            }

            _dbSet = _dbSet.Where(filter);

            if (includeFunc != null) 
            {
                _dbSet = includeFunc(_dbSet);
            }

            if (orderBy != null) 
            {
                _dbSet = orderBy(_dbSet);
            }

            return await _dbSet.ToListAsync();
            
        }

        public async Task<IEnumerable<TEntity>> GetCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeFunc = null, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> _dbSet = dbSet.AsQueryable();

            if (skip.HasValue)
            {
                _dbSet = _dbSet.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                _dbSet = _dbSet.Take(take.Value);
            }

            if (filter != null) 
            {
                _dbSet = _dbSet.Where(filter);
            }

            if (orderBy != null) 
            {
                _dbSet = orderBy(_dbSet);
            }

            if (includeFunc != null) 
            {
                _dbSet = includeFunc(_dbSet);
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TResponse>> GetWithGroupByAsync<TResponse>(Func<TEntity, object> groupBy, Func<IGrouping<object, TEntity>, TResponse> select,
            Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> _dbSet = dbSet.AsQueryable();

            if (filter != null)
            {
                _dbSet = _dbSet.Where(filter);
            }

            if (orderBy != null)
            {
                _dbSet = orderBy(_dbSet);
            }

            var grouped = (await _dbSet.ToListAsync()).GroupBy(groupBy);
            var _select = grouped.Select(select);
            return _select;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync() => await dbContext.SaveChangesAsync() > 0;
    }
}
