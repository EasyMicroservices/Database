using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.MongoDB.Providers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.Tests.Providers.MongoDBProviders
{
    public class MongoDBProviderTest : BaseDatabaseProviderTest
    {
        public MongoDBProviderTest() : base(new MongoDatabaseProvider(new MongoClient("mongodb://localhost").GetDatabase("EasyMicroservicesTest")))
        {

        }
    }
}
