using Microsoft.EntityFrameworkCore;
using RentACarApi.Models;

namespace RentACarApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Red"},
                new Color { Id = 2, Name = "Blue"},
                new Color { Id = 3, Name = "Green"},
                new Color { Id = 4, Name = "Black" },
                new Color { Id = 5, Name = "White" },
                new Color { Id = 6, Name = "Gray" },
                new Color { Id = 7, Name = "Yellow" },
                new Color { Id = 8, Name = "Orange" },
                new Color { Id = 9, Name = "Purple" }
                );

            modelBuilder.Entity<Fuel>().HasData(
                new Fuel { Id = 1, Name = "Gasoline" },
                new Fuel { Id = 2, Name = "Diesel" },
                new Fuel { Id = 3, Name = "Electricity" }
                );

            modelBuilder.Entity<Transmission>().HasData(
                new Transmission { Id = 1, Name = "Automatic"},
                new Transmission { Id = 2, Name = "Manual" }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, ColorId = 1, FuelId = 3, TransmissionId = 1, CarState = "Available", KiloMeter = 15000, ModelYear = 2016, Plate = "34 AB 1456", BrandName = "Mercedes Benz", ModelName = "EQC", DailyPrice = 500.00 },
                new Car { Id = 2, ColorId = 2, FuelId = 3, TransmissionId = 1, CarState = "Available", KiloMeter = 30000, ModelYear = 2018, Plate = "34 BR 8482", BrandName = "Mercedes Benz", ModelName = "EQS", DailyPrice = 1000.00 },
                new Car { Id = 3, ColorId = 3, FuelId = 3, TransmissionId = 1, CarState = "Available", KiloMeter = 40000, ModelYear = 2019, Plate = "34 MA 3341", BrandName = "Mercedes Benz", ModelName = "EQA", DailyPrice = 1500.00 },
                new Car { Id = 4, ColorId = 4, FuelId = 3, TransmissionId = 1, CarState = "On Rent", KiloMeter = 20000, ModelYear = 2022, Plate = "41 V 1756", BrandName = "Mercedes Benz", ModelName = "EQS SUV", DailyPrice = 1200.00 },
                new Car { Id = 5, ColorId = 5, FuelId = 1, TransmissionId = 2, CarState = "On Rent", KiloMeter = 22000, ModelYear = 2024, Plate = "41 AB 8601", BrandName = "Mercedes Benz", ModelName = "CLA", DailyPrice = 800.00 },
                new Car { Id = 6, ColorId = 6, FuelId = 1, TransmissionId = 2, CarState = "Available", KiloMeter = 14000, ModelYear = 2018, Plate = "41 AN 2016", BrandName = "Mercedes Benz", ModelName = "E-Class", DailyPrice = 900.00 },
                new Car { Id = 7, ColorId = 7, FuelId = 2, TransmissionId = 1, CarState = "Available", KiloMeter = 55000, ModelYear = 2019, Plate = "16 DE 2856", BrandName = "BMW", ModelName = "X5", DailyPrice = 750.00 },
                new Car { Id = 8, ColorId = 8, FuelId = 2, TransmissionId = 1, CarState = "Available", KiloMeter = 35000, ModelYear = 2016, Plate = "16 TU 2230", BrandName = "BMW", ModelName = "X7", DailyPrice = 900.00 },
                new Car { Id = 9, ColorId = 9, FuelId = 1, TransmissionId = 1, CarState = "In Care", KiloMeter = 60000, ModelYear = 2018, Plate = "35 MN 4546", BrandName = "Audi", ModelName = "A8", DailyPrice = 1300.00 },
                new Car { Id = 10, ColorId = 1, FuelId = 1, TransmissionId = 1, CarState = "In Care", KiloMeter = 75000, ModelYear = 2020, Plate = "35 YU 9402", BrandName = "Audi", ModelName = "Q7", DailyPrice = 1500.00 }
                );
        }


    }
}
