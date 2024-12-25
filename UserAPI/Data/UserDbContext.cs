using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Data
{
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public UserDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "Alice Johnson",
                    Address = "123 Maple Street, Springfield"
                },
                new User
                {
                    UserId = 2,
                    UserName = "Bob Smith",
                    Address = "456 Oak Avenue, Metropolis"
                },
                new User
                {
                    UserId = 3,
                    UserName = "Charlie Brown",
                    Address = "789 Pine Road, Gotham"
                }
            );
        }
        public DbSet<User> Users { get; set; }
    }
}
