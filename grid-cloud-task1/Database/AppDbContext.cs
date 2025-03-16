using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace grid_cloud_task1.Database
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasData();
        }
    }
}
