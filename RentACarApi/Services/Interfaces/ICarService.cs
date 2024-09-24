using RentACarApi.Dtos;
using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface ICarService : IService<Car>
    {
        public Task<List<CarDetailDto>> GetAllDetailsAsync();

        public Task<List<CarDetailDto>> GetAllDetailsByFuelIdAsync(int fuelId);

        public Task<List<CarDetailDto>> GetAllDetailsByColorIdAsync(int colorId);

        public Task<List<CarDetailDto>> GetAllDetailsByPriceRangeAsync(double min, double max);

        public Task<List<CarDetailDto>> GetAllDetailsByBrandNameContainsAsync(string brandName);

        public Task<List<CarDetailDto>> GetAllDetailsByModelNameContainsAsync(string modelName);

        public Task<CarDetailDto?> GetDetailByIdAsync(int id);

        public Task<List<CarDetailDto>> GetAllDetailsByKilometerRangeAsync(int min, int max);
    }
}
