using EasyMicroservices.Database.DataTypes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContext : IDisposable
#if (!NETSTANDARD2_0 && !NET45)
, IAsyncDisposable
#endif
    {
        /// <summary>
        /// database context type
        /// </summary>
        Type ContextType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetContextName();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="isModified"></param>
        void ChangeModificationPropertyState<T>(T entity, string property, bool isModified)
            where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="entityStateType"></param>
        public void ChangeEntityState<T>(T entity, EntityStateType entityStateType)
            where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEntityEntry Entry<T>(T entity)
            where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        IEnumerable<IPropertyEntry> GetProperties<T>(T entity)
            where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<IPropertyEntry> GetProperties(object entity);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEntityEntry> GetTrackerEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        object[] GetPrimaryKeyValues<TEntity>(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        Task Reload<T>(T entity, CancellationToken cancellationToken)
            where T : class;
    }
}
