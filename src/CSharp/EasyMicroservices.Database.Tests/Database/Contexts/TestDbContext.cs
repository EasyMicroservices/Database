using EasyMicroservices.Database.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.Database.Tests.Database.Contexts
{
    public class TestDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("TestDbContext");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(e =>
            {
                e.HasKey(x => x.Id);
            });
        }
    }
}
