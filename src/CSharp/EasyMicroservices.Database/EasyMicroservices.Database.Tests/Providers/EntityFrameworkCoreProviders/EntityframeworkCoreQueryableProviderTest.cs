using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Tests.Database.Contexts;
using EasyMicroservices.Database.Tests.Database.Entities;

namespace EasyMicroservices.Database.Tests.Providers.EntityFrameworkCoreProviders
{
    public class EntityframeworkCoreQueryableProviderTest : BaseQueryableProviderTest
    {
        public EntityframeworkCoreQueryableProviderTest() : base(new EntityframeworkCoreDatabaseProvider(new TestDbContext()).GetQueryOf<UserEntity>())
        {

        }
    }
}
