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

        /// <summary>
        /// 
        /// </summary>
        public object OrginalValue
        {
            get
            {
                return _PropertyEntry.OriginalValue;
            }
            set
            {
                _PropertyEntry.OriginalValue = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object CurrentValue
        {
            get
            {
                return _PropertyEntry.CurrentValue;
            }
            set
            {
                _PropertyEntry.CurrentValue = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IProperty Metadata
        {
            get
            {
                return new Property(_PropertyEntry.Metadata);
            }
        }
    }
}
