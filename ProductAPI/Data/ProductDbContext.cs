using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ProductDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ProductDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'DefaultConnection' is not configured.");
            }

            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop X Pro",
                    ProductDescription = "A high-performance laptop ideal for work and entertainment.",
                    ProductPrice = 1500,
                    ProductStock = 25
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Smartphone Ultra",
                    ProductDescription = "A cutting-edge smartphone with superior camera quality and long battery life.",
                    ProductPrice = 1000,
                    ProductStock = 50
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Wireless Earbuds 360",
                    ProductDescription = "Compact wireless earbuds offering immersive sound and active noise cancellation.",
                    ProductPrice = 200,
                    ProductStock = 100
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
