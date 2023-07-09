using System;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEasyQueryableBaseAsync
    {
        /// <summary>
        /// database context
        /// </summary>
        IContext Context { get; set; }
    }
}
