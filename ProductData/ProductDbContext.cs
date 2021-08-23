using Microsoft.EntityFrameworkCore;
using ProductCore;

namespace ProductData
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
        }

        public DbSet<Product> Products { get; set; }
    }
}
