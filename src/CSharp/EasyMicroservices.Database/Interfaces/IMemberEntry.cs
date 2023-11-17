namespace EasyMicroservices.Database.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemberEntry
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsModified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object CurrentValue { get; set; }
    }
}
