using System;
using System.Threading;
using System.Threading.Tasks;

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
        /// <param name="cancellationToken"></param>
        Task Reload<T>(T entity, CancellationToken cancellationToken)
            where T : class;
    }
}
