using EasyMicroservices.Database.MongoDB.Providers;
using EasyMicroservices.Database.Tests.Database.MongoDBDocuments;
using MongoDB.Driver;

namespace EasyMicroservices.Database.Tests.Providers.MongoDBProviders
{
    public class MongoDBQueryableProviderTest : BaseQueryableProviderTest<UserDocument>
    {
        public MongoDBQueryableProviderTest() : base(new MongoDatabaseProvider(new MongoClient("mongodb://localhost").GetDatabase("EasyMicroservicesTest")).GetQueryOf<UserDocument>())
        {

        }
    }
}
