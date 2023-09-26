using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.Tests.Database.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Database.Tests.Providers
{
    public abstract class BaseQueryableProviderTest<TUser>
        where TUser : class, IUser, new()
    {
        public IEasyQueryableAsync<TUser> Queryable { get; set; }
        public BaseQueryableProviderTest(IEasyQueryableAsync<TUser> queryable)
        {
            Queryable = queryable;
        }

        [Fact]
        public virtual async Task GetDatabaseProvider()
        {
            await Queryable.AnyAsync();
        }

        [Theory]
        [InlineData("Ali")]
        public virtual async Task AddAsync(string name)
        {
            if (await Queryable.AnyAsync(x => x.Name == name))
                await Queryable.RemoveAllAsync(x => x.Name == name);
            Assert.False(await Queryable.AnyAsync(x => x.Name == name));
            var result = await Queryable.AddAsync(new TUser()
            {
                Name = name
            });
            await Queryable.SaveChangesAsync();
            Assert.True(await Queryable.AnyAsync(x => x.Name == name));
        }

        [Theory]
        [InlineData("Update Ali", "Update to reza")]
        public virtual async Task UpdateAsync(string name, string updateToName)
        {
            if (await Queryable.AnyAsync(x => x.Name == name))
                await Queryable.RemoveAllAsync(x => x.Name == name);
            Assert.False(await Queryable.AnyAsync(x => x.Name == name));
            var result = await Queryable.AddAsync(new TUser()
            {
                Name = name
            });
            await Queryable.SaveChangesAsync();
            var find = await Queryable.FirstOrDefaultAsync(x => x.Name == name);
            Assert.NotNull(find);
            find.Name = updateToName;
            await Queryable.UpdateAsync(find);
            Assert.True(await Queryable.AnyAsync(x => x.Name == updateToName));
        }
    }
}
