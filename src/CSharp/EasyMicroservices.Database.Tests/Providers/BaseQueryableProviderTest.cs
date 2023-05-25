using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.Tests.Database.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Database.Tests.Providers
{
    public abstract class BaseQueryableProviderTest<TUser>
        where TUser : class, IUser, new()
    {
        IEasyQueryableAsync<TUser> _queryable;
        public BaseQueryableProviderTest(IEasyQueryableAsync<TUser> queryable)
        {
            _queryable = queryable;
        }

        [Fact]
        public virtual async Task GetDatabaseProvider()
        {
            await _queryable.AnyAsync();
        }

        [Theory]
        [InlineData("Ali")]
        public virtual async Task AddAsync(string name)
        {
            if (await _queryable.AnyAsync(x => x.Name == name))
                await _queryable.RemoveAllAsync(x => x.Name == name);
            Assert.False(await _queryable.AnyAsync(x => x.Name == name));
            var result = await _queryable.AddAsync(new TUser()
            {
                Name = name
            });
            await _queryable.SaveChangesAsync();
            Assert.True(await _queryable.AnyAsync(x => x.Name == name));
        }

        [Theory]
        [InlineData("Update Ali", "Update to reza")]
        public virtual async Task UpdateAsync(string name, string updateToName)
        {
            if (await _queryable.AnyAsync(x => x.Name == name))
                await _queryable.RemoveAllAsync(x => x.Name == name);
            Assert.False(await _queryable.AnyAsync(x => x.Name == name));
            var result = await _queryable.AddAsync(new TUser()
            {
                Name = name
            });
            await _queryable.SaveChangesAsync();
            var find = await _queryable.FirstOrDefaultAsync(x => x.Name == name);
            Assert.NotNull(find);
            find.Name = updateToName;
            await _queryable.Update(find);
            Assert.True(await _queryable.AnyAsync(x => x.Name == updateToName));
        }
    }
}
