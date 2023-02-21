using Microsoft.EntityFrameworkCore;
using UnitConverter.Api.Data.Seeders;
using UnitConverter.Api.Entities;

namespace UnitConverter.Api.Data
{
   public class ConversionRateDbContext : DbContext
    {
        public ConversionRateDbContext(DbContextOptions<ConversionRateDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedConversionRate();
        }


        public DbSet<ConversionRate> ConversionRates { get; set; }
    }
}
