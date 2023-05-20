using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.Tests.Database.Entities;
using Xunit;

namespace EasyMicroservices.Database.Tests.Providers
{
    public abstract class BaseDatabaseProviderTest
    {
        IDatabase _database;
        public BaseDatabaseProviderTest(IDatabase database)
        {
            _database = database;
        }

        [Fact]
        public virtual void GetDatabaseProvider()
        {
            var query = _database.GetQueryOf<UserEntity>();
            Assert.NotNull(query);
        }
    }
}
