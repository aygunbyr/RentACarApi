using RentACarApi.Dtos;
using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        public List<CarDetailDto> GetAllDetails();

        public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId);

        public List<CarDetailDto> GetAllDetailsByColorId(int colorId);

        public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max);

        public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName);

        public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName);

        public CarDetailDto? GetDetailById(int id);

        public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max);
    }
}
