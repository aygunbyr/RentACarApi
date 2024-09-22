using RentACarApi.Dtos;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Car car)
        {
            _unitOfWork.Car.Add(car);
        }

        public void Delete(Car car)
        {
            _unitOfWork.Car.Delete(car);
        }

        public IEnumerable<Car> GetAll()
        {
            IEnumerable<Car> cars = _unitOfWork.Car.GetAll();
            return cars;
        }

        public Car GetById(int id)
        {
            Car car = _unitOfWork.Car.GetById(id);
            return car;
        }

        public void Update(Car car)
        {
            _unitOfWork.Car.Update(car);
        }

        public List<CarDetailDto> GetAllDetails()
        {
            return _unitOfWork.Car.GetAllDetails();
        }

        public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
        {
            return _unitOfWork.Car.GetAllDetailsByFuelId(fuelId);
        }

        public List<CarDetailDto> GetAllDetailsByColorId(int colorId)
        {
            return _unitOfWork.Car.GetAllDetailsByColorId(colorId);
        }

        public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
        {
            return _unitOfWork.Car.GetAllDetailsByPriceRange(min, max);
        }

        public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName)
        {
            return _unitOfWork.Car.GetAllDetailsByBrandNameContains(brandName);
        }

        public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
        {
            return _unitOfWork.Car.GetAllDetailsByBrandNameContains(modelName);
        }

        public CarDetailDto? GetDetailById(int id)
        {
            return _unitOfWork.Car.GetDetailById(id);
        }

        public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
        {
            return _unitOfWork.Car.GetAllDetailsByKilometerRange(min, max);
        }
    }
}
