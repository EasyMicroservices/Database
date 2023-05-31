using EasyMicroservices.Database.EntityFrameworkCore.Providers;
using EasyMicroservices.Database.Tests.Database.Contexts;
using EasyMicroservices.Database.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Database.Tests.Providers.EntityFrameworkCoreProviders
{
    public class EntityframeworkCoreQueryableProviderTest : BaseQueryableProviderTest<UserEntity>
    {
        public EntityframeworkCoreQueryableProviderTest() : base(new EntityFrameworkCoreDatabaseProvider(new TestDbContext()).GetQueryOf<UserEntity>())
        {

        }



        [Theory]
        [InlineData("Ali include", "Hello world")]
        [InlineData("Mahdi include", "Hello world 2")]
        public virtual async Task IncludeTestAsync(string name, string postTitle)
        {
            if (await Queryable.AnyAsync(x => x.Name == name))
                await Queryable.RemoveAllAsync(x => x.Name == name);
            Assert.False(await Queryable.AnyAsync(x => x.Name == name));
            var result = await Queryable.AddAsync(new UserEntity()
            {
                Name = name,
                Posts = new List<PostEntity>()
                {
                    new PostEntity()
                    {
                         Title = postTitle
                    }
                }
            });
            await Queryable.SaveChangesAsync();
            Assert.True(await Queryable.AnyAsync(x => x.Name == name));
            var myQueryable = new EntityFrameworkCoreDatabaseProvider(new TestDbContext()).GetQueryOf<UserEntity>();
            var getWithoutInclude = await myQueryable.FirstOrDefaultAsync(x => x.Name == name);
            Assert.True(getWithoutInclude.Posts == null);
            var getWithInclude = await myQueryable.ConvertToReadable(myQueryable.Include(x => x.Posts)).FirstOrDefaultAsync(x => x.Name == name);
            Assert.True(getWithInclude.Posts != null);
        }
    }
}
