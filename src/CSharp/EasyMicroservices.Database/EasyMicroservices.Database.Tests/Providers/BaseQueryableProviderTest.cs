using EasyMicroservices.Database.Interfaces;
using EasyMicroservices.Database.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Database.Tests.Providers
{
    public abstract class BaseQueryableProviderTest
    {
        IEasyQueryableAsync<UserEntity> _queryable;
        public BaseQueryableProviderTest(IEasyQueryableAsync<UserEntity> queryable)
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
            var result = await _queryable.AddAsync(new UserEntity()
            {
                Name = name
            });
            Assert.False(await _queryable.AnyAsync(x => x.Name == name));
            await _queryable.SaveChangesAsync();
            Assert.True(await _queryable.AnyAsync(x => x.Name == name));
        }
    }
}
