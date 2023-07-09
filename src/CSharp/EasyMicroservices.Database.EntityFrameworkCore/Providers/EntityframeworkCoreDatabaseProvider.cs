using EasyMicroservices.Database.EntityFrameworkCore.Implementations;
using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityFrameworkCoreDatabaseProvider : IDatabase
    {
        private readonly DbContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public EntityFrameworkCoreDatabaseProvider(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IEasyQueryableAsync<TEntity> GetQueryOf<TEntity>() where TEntity : class
        {
            return new QueryableProvider<TEntity>(new DatabaseContext(_dbContext), GetReadableOf<TEntity>(), GetWritableOf<TEntity>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEasyReadableQueryableAsync<TEntity> GetReadableOf<TEntity>() where TEntity : class
        {
            return new EntityFrameworkCoreReadableQueryableProvider<TEntity>(new DatabaseContext(_dbContext), _dbContext.Set<TEntity>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEasyWritableQueryableAsync<TEntity> GetWritableOf<TEntity>() where TEntity : class
        {
            return new EntityFrameworkCoreWritableQueryableProvider<TEntity>(_dbContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
