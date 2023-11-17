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
    }
}
