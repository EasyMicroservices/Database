using System;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEasyQueryableBaseAsync : IDisposable
#if (!NETSTANDARD2_0 && !NET45)
,IAsyncDisposable
#endif
    {
        /// <summary>
        /// database context
        /// </summary>
        IContext Context { get; set; }
    }
}
