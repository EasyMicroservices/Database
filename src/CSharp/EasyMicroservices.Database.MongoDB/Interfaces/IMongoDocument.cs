using MongoDB.Bson;

namespace EasyMicroservices.Database.MongoDB.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMongoDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
