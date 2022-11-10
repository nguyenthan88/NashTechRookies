using Microsoft.EntityFrameworkCore;
using Test.Data.Configurations;
using Test.Data.Entities;

namespace Test.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Book> Books { get; set; }

/*        public DbSet<User> Users { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookInCategoryConfiguration());
        }
    }
}