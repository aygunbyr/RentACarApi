using RentACarApi.Models;
using RentACarApi.Repositories;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class FuelService : IFuelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FuelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Fuel fuel)
        {
            _unitOfWork.Fuel.Add(fuel);
        }

        public void Delete(Fuel fuel)
        {
            _unitOfWork.Fuel.Delete(fuel);
        }

        public IEnumerable<Fuel> GetAll()
        {
            IEnumerable<Fuel> fuels = _unitOfWork.Fuel.GetAll();
            return fuels;
        }

        public Fuel GetById(int id)
        {
            Fuel fuel = _unitOfWork.Fuel.GetById(id);
            return fuel;
        }

        public void Update(Fuel fuel)
        {
            _unitOfWork.Fuel.Update(fuel);
        }
    }
}
