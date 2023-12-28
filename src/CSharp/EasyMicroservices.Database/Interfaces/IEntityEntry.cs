using EasyMicroservices.Database.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntityEntry<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        TEntity Entity { get; }
        /// <summary>
        /// 
        /// </summary>
        EntityStateType EntityState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ReloadAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task ReloadAsync(string propertyName);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        IEntityEntry<TEntity> GetEntityEntry<TProperty>(Expression<Func<TEntity, IEnumerable<TProperty>>> func)
            where TProperty : class;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        IEntityEntry GetEntityEntry(string propertyName);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityEntry
    {
        /// <summary>
        /// 
        /// </summary>
        object Entity { get; }
        /// <summary>
        /// 
        /// </summary>
        EntityStateType EntityState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task ReloadAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task ReloadAsync(string propertyName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        IEntityEntry GetEntityEntry(string propertyName);
    }
}
