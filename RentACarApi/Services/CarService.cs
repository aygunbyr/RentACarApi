using RentACarApi.Models;
using RentACarApi.Models.Dtos;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class CarService : IService<Car>, ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Car car)
        {
            _unitOfWork.Car.Add(car);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            _unitOfWork.Car.Delete(car);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            IEnumerable<Car> cars = await _unitOfWork.Car.GetAllAsync();
            return cars;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            Car car = await _unitOfWork.Car.GetByIdAsync(id);
            return car;
        }

        public async Task UpdateAsync(Car car)
        {
            _unitOfWork.Car.Update(car);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CarDetailDto>> GetAllDetailsAsync()
        {
            var details = await _unitOfWork.Car.GetAllDetails();
            return details;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByFuelIdAsync(int fuelId)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByFuelId(fuelId);
            return details;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByColorIdAsync(int colorId)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByColorId(colorId);
            return details;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByPriceRangeAsync(double min, double max)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByPriceRange(min, max);
            return details;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByBrandNameContainsAsync(string brandName)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByBrandNameContains(brandName);
            return details;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByModelNameContainsAsync(string modelName)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByModelNameContains(modelName);
            return details;
        }

        public async Task<CarDetailDto?> GetDetailByIdAsync(int id)
        {
            var detail = await _unitOfWork.Car.GetDetailById(id);
            return detail;
        }

        public async Task<List<CarDetailDto>> GetAllDetailsByKilometerRangeAsync(int min, int max)
        {
            var details = await _unitOfWork.Car.GetAllDetailsByKilometerRange(min, max);
            return details;
        }
    }
}
