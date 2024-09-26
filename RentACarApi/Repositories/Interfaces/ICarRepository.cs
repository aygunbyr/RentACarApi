using RentACarApi.Models;
using RentACarApi.Models.Dtos;

namespace RentACarApi.Repositories.Interfaces
{
    public interface ICarRepository : IRepository<Car, long>
    {
        public Car Update(Car car);

        public Task<List<CarDetailDto>> GetAllDetails();

        public Task<List<CarDetailDto>> GetAllDetailsByFuelId(int fuelId);

        public Task<List<CarDetailDto>> GetAllDetailsByColorId(int colorId);

        public Task<List<CarDetailDto>> GetAllDetailsByPriceRange(double min, double max);

        public Task<List<CarDetailDto>> GetAllDetailsByBrandNameContains(string brandName);

        public Task<List<CarDetailDto>> GetAllDetailsByModelNameContains(string modelName);

        public Task<CarDetailDto?> GetDetailById(long id);

        public Task<List<CarDetailDto>> GetAllDetailsByKilometerRange(int min, int max);
    }
}
