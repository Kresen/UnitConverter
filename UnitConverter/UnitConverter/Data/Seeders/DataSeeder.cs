using Microsoft.EntityFrameworkCore;
using UnitConverter.Api.Entities;

namespace UnitConverter.Api.Data.Seeders
{
    public static class DataSeeder
    {
        public static void SeedConversionRate(this ModelBuilder modelBuilder)
        {
            List<ConversionRate> list = new List<ConversionRate>(){ new ConversionRate
            {
                Id= 1,
                UnitFrom = "Celsius",
                UnitTo = "Fahrenheit",
                Rate = 1.8m

            },
            new ConversionRate{
                Id= 2,
                UnitFrom = "Kilometers",
                UnitTo = "Miles",
                Rate = 0.621371m

            },
               new ConversionRate{
                Id= 3,
                UnitFrom = "Kilograms",
                UnitTo = "Pounds",
                Rate = 2.20462m

            },
                new ConversionRate{
                Id= 4,
                UnitFrom = "Liters",
                UnitTo = "Gallons",
                Rate = 0.264172m

            },
                new ConversionRate{
                Id= 5,
                UnitFrom = "Meters",
                UnitTo = "Feet",
                Rate = 3.28084m

            }
        };

            modelBuilder.Entity<ConversionRate>().HasData(list);
        }
    }
}
