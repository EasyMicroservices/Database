using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.Implementations
{
    internal class DatabaseContext : IContext
    {
        public DatabaseContext(DbContext dbContext)
        {
            _dbContext = dbContext;
            ContextType = _dbContext.GetType();
        }

        DbContext _dbContext;
        public Type ContextType { get; set; }

        public string GetContextName()
        {
            return ContextType.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="isModified"></param>
        public void ChangeModificationPropertyState<T>(T entity, string property, bool isModified)
            where T : class
        {
            _dbContext.Entry(entity).Property(property).IsModified = isModified;
        }

        public Task Reload<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            return _dbContext.Entry(entity).ReloadAsync(cancellationToken);
        }
    }
}
