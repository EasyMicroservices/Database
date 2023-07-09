using System;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContext
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
    }
}
