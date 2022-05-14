using Microsoft.EntityFrameworkCore;
using Minecraft.Models;

namespace Minecraft.Data
{
    public class DataContext : DbContext
    {
        public readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseInMemoryDatabase("testdb");
        }

        public DbSet<Plinth> Plinths { get; set; }

        public DbSet<Minecraft.Models.Order> Order { get; set; }
    }
}
