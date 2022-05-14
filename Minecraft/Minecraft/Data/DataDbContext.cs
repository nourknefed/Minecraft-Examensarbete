using Microsoft.EntityFrameworkCore;
using Minecraft.Models;

namespace Minecraft.Data
{
    public class DataDbContext : DbContext
    {
        public readonly IConfiguration Configuration;

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Downloads\Examensarbete\Minecraft\Minecraft\Models.mdf;Integrated Security=True;Connect Timeout=30");
        
            
            
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Minecraft.Models.Plinth> Plinth { get; set; }

    }
}
