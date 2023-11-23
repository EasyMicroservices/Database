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
        public TEntity Entity { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IEntityEntry
    {
        /// <summary>
        /// 
        /// </summary>
        public object Entity { get; }
    }
}
