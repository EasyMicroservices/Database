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

        [Theory]
        [InlineData("Ali load 2", "Hello world load")]
        [InlineData("Mahdi load 2", "Hello world 2 load")]
        public virtual async Task ReloadTestAsync(string name, string postTitle)
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
            await myQueryable.Context.Entry(getWithoutInclude).ReloadCollectionAsync(nameof(UserEntity.Posts));
            Assert.True(getWithoutInclude.Posts != null);


            var myPostQueryable = new EntityFrameworkCoreDatabaseProvider(new TestDbContext()).GetQueryOf<PostEntity>();
            var getPostWithoutInclude = await myPostQueryable.FirstOrDefaultAsync(x => x.Title == postTitle);
            Assert.True(getPostWithoutInclude.User == null);
            await myPostQueryable.Context.Entry(getPostWithoutInclude).ReloadReferenceAsync(nameof(PostEntity.User));
            Assert.True(getPostWithoutInclude.User != null);
        }
    }
}
