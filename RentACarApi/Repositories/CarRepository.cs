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

        public Car Update(Car car)
        {
            try
            {
                var existingCar = _db.Cars.FirstOrDefault(x => x.Id == car.Id);
                if (existingCar == null)
                {
                    throw new KeyNotFoundException($"Car with id {car.Id} not found");
                }
                existingCar.ColorId = car.ColorId;
                existingCar.FuelId = car.FuelId;
                existingCar.TransmissionId = car.TransmissionId;
                existingCar.CarState = car.CarState;
                existingCar.KiloMeter = car.KiloMeter;
                existingCar.ModelYear = car.ModelYear;
                existingCar.Plate = car.Plate;
                existingCar.BrandName = car.BrandName;
                existingCar.ModelName = car.ModelName;
                existingCar.DailyPrice = car.DailyPrice;
                _db.Cars.Update(existingCar);
                return existingCar;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetails()
        {
            try
            {
                var details = await _db.Cars
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
                )).ToListAsync();
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving car details", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByFuelId(int fuelId)
        {
            try
            {
                var details = await _db.Cars
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
                )).ToListAsync();
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving car details by Fuel Id {fuelId}", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByColorId(int colorId)
        {
            try
            {
                var details = await _db.Cars
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
                )).ToListAsync();
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving car details by Color Id {colorId}", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByPriceRange(double min, double max)
        {
            try
            {
                var details = await _db.Cars
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
                )).ToListAsync();
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving car details by price range {min}-{max}", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByBrandNameContains(string brandName)
        {
            try
            {
                var details = await _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.BrandName.ToLower().Contains(brandName.ToLower()))
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
                )).ToListAsync();
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving car details by brand name contains {brandName}", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByModelNameContains(string modelName)
        {
            try
            {
                var details = await _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .Where(car => car.ModelName.ToLower().Contains(modelName.Trim().ToLower()))
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
                )).ToListAsync();
                return details;
            } 
            catch(Exception ex)
            {
                throw new Exception($"Error retrieving car details by model name contains {modelName}", ex);
            }
        }

        public async Task<CarDetailDto?> GetDetailById(int id)
        {
            try
            {
                var car = await _db.Cars
                .Include(car => car.Fuel)
                .Include(car => car.Transmission)
                .Include(car => car.Color)
                .FirstOrDefaultAsync(car => car.Id == id);

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
            catch(Exception ex)
            {
                throw new Exception($"Error retrieving car detail by id {id}", ex);
            }
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByKilometerRange(int min, int max)
        {
            try
            {
                var details =  await _db.Cars
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
                )).ToListAsync();
                return details;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error retrieving car details by kilometer range {min}-{max}", ex);
            }
        }
    }
}
