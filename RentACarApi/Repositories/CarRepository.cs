using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Dtos;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<CarDetailDto> GetAllDetails()
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.FuelId == fuelId)
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public List<CarDetailDto> GetAllDetailsByColorId(int colorId)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.ColorId == colorId)
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.DailyPrice >= min && car.DailyPrice <= max)
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.BrandName.Contains(brandName, StringComparison.InvariantCultureIgnoreCase))
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.ModelName.Contains(modelName, StringComparison.InvariantCultureIgnoreCase))
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }

        public CarDetailDto? GetDetailById(int id)
        {
            var car = _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .FirstOrDefault(car => car.Id == id);

            if (car == null)
                return null;

            return new CarDetailDto(
                car.Id,
                car.Fuel.Name,
                car.Transmission.Name,
                car.Color.Name,
                car.CarState,
                car.KiloMeter,
                car.ModelYear,
                car.Plate,
                car.BrandName,
                car.ModelName,
                car.DailyPrice
            );
        }

        public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
        {
            return _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.KiloMeter >= min && car.KiloMeter <= max)
                .Select(car => new CarDetailDto(
                    car.Id,
                    car.Fuel.Name,
                    car.Transmission.Name,
                    car.Color.Name,
                    car.CarState,
                    car.KiloMeter,
                    car.ModelYear,
                    car.Plate,
                    car.BrandName,
                    car.ModelName,
                    car.DailyPrice
                )).ToList();
        }
    }
}
