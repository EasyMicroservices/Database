using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Tests.Database.Contexts;

namespace EasyMicroservices.Database.Tests.Providers.EntityFrameworkCoreProviders
{
    public class EntityframeworkCoreDatabaseProviderTest : BaseDatabaseProviderTest
    {
        public EntityframeworkCoreDatabaseProviderTest() : base(new EntityframeworkCoreDatabaseProvider(new TestDbContext()))
        {

        }
    }
}
