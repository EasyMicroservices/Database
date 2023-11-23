using EasyMicroservices.Database.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
