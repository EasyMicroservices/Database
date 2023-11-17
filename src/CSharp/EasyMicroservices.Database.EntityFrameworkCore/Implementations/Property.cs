using EasyMicroservices.Database.Interfaces;
using System;
using System.Reflection;

namespace EasyMicroservices.Database.EntityFrameworkCore.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class Property : IProperty
    {
        Microsoft.EntityFrameworkCore.Metadata.IProperty _property;
        /// <summary>
        /// 
        /// </summary>
        public Property(Microsoft.EntityFrameworkCore.Metadata.IProperty property)
        {
            _property = property;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType
        {
            get
            {
                return _property.ClrType;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Type DeclaringType
        {
            get
            {
                return _property.DeclaringType.ClrType;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return _property.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo
        {
            get
            {
                return _property.PropertyInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldInfo FieldInfo
        {
            get
            {
                return _property.FieldInfo;
            }
        }
    }
}
