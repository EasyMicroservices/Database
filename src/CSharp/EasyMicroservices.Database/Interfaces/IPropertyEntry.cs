namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPropertyEntry : IMemberEntry
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsTemporary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object OrginalValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IProperty Metadata { get; }
    }
}
