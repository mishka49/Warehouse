using Microsoft.EntityFrameworkCore;
using WarehouseApp.Models;

namespace WarehouseApp.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WarehouseDatabase"));
        }

        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

    }
}
