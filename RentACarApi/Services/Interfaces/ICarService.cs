using RentACarApi.Dtos;
using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

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
