using EasyMicroservices.Database.MongoDB.Interfaces;
using EasyMicroservices.Database.Tests.Database.Interfaces;
using MongoDB.Bson;

namespace EasyMicroservices.Database.Tests.Database.MongoDBDocuments
{
    public class UserDocument : IUser, IMongoDocument
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
