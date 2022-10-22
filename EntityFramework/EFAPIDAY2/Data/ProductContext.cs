using EFAPIDAY2.Models;
using Microsoft.EntityFrameworkCore;
namespace EFAPIDAY2.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .ToTable("Category")
                        .HasKey(Cat => Cat.Id);

            modelBuilder.Entity<Category>()
                        .Property(Cat => Cat.Id)
                        .HasColumnName("CategoryID")
                        .HasColumnType("int")
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .Property(Cat => Cat.CategoryName)
                        .HasColumnName("CategoryName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .ToTable("Product")
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(p => p.Category)
                        .WithMany(p => p.Products)
                        .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .HasColumnName("ProductID")
                        .HasColumnType("int")
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(p => p.ProductName)
                        .HasColumnName("ProductName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(p => p.Manufacture)
                        .HasColumnName("Manufacture")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();
            modelBuilder.Entity<Category>()
                        .HasData(new Category
                        {
                            Id = 1,
                            CategoryName = "Computers"
                        });
            modelBuilder.Entity<Product>()
                        .HasData(new Product
                        {
                            Id = 1,
                            ProductName = "Laptop Dell",
                            Manufacture = "Viet Nam",
                            CategoryId = 1
                        });
        }
    }
}