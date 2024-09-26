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
        public async Task<Fuel> AddAsync(Fuel fuel)
        {
            Fuel fuelAdded = _unitOfWork.Fuel.Add(fuel);
            await _unitOfWork.SaveAsync();
            return fuelAdded;
        }

        public async Task<Fuel> DeleteAsync(Fuel fuel)
        {
            Fuel fuelDeleted = _unitOfWork.Fuel.Delete(fuel);
            await _unitOfWork.SaveAsync();
            return fuelDeleted;
        }

        public async Task<IEnumerable<Fuel>> GetAllAsync()
        {
            IEnumerable<Fuel> fuels = await _unitOfWork.Fuel.GetAllAsync();
            return fuels;
        }

        public async Task<Fuel> GetByIdAsync(int id)
        {
            Fuel fuel = await _unitOfWork.Fuel.GetByIdAsync(id);
            return fuel;
        }

        public async Task<Fuel> UpdateAsync(Fuel fuel)
        {
            Fuel fuelUpdated = _unitOfWork.Fuel.Update(fuel);
            await _unitOfWork.SaveAsync();
            return fuelUpdated;
        }
    }
}
