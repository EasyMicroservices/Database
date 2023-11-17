using EasyMicroservices.Database.Interfaces;

namespace EasyMicroservices.Database.EntityFrameworkCore.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyEntry : IPropertyEntry
    {
        Microsoft.EntityFrameworkCore.ChangeTracking.PropertyEntry _PropertyEntry;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyEntry"></param>
        public PropertyEntry(Microsoft.EntityFrameworkCore.ChangeTracking.PropertyEntry propertyEntry)
        {
            _PropertyEntry = propertyEntry;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTemporary
        {
            get
            {
                return _PropertyEntry.IsTemporary;
            }
            set
            {
                _PropertyEntry.IsTemporary = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsModified
        {
            get
            {
                return _PropertyEntry.IsModified;
            }
            set
            {
                _PropertyEntry.IsModified = value;
            }
        }
    }
}
