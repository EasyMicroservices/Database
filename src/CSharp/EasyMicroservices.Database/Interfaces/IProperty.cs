using System;
using System.Reflection;

namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// 
        /// </summary>
        Type ClrType { get; }
        /// <summary>
        /// 
        /// </summary>
        Type DeclaringType { get; }
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        PropertyInfo PropertyInfo { get; }
        /// <summary>
        /// 
        /// </summary>
        FieldInfo FieldInfo { get; }
    }
}
