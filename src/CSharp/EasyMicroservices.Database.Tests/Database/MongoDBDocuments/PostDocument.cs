using EasyMicroservices.Database.MongoDB.Interfaces;
using EasyMicroservices.Database.Tests.Database.Interfaces;
using MongoDB.Bson;

namespace EasyMicroservices.Database.Tests.Database.MongoDBDocuments
{
    public class PostDocument : IPost, IMongoDocument
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
    }
}
