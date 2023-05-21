using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Tests.Database.Contexts;
using EasyMicroservices.Database.Tests.Database.Entities;

namespace EasyMicroservices.Database.Tests.Providers.EntityFrameworkCoreProviders
{
    public class EntityframeworkCoreQueryableProviderTest : BaseQueryableProviderTest<UserEntity>
    {
        public EntityframeworkCoreQueryableProviderTest() : base(new EntityFrameworkCoreDatabaseProvider(new TestDbContext()).GetQueryOf<UserEntity>())
        {

        }
    }
}
