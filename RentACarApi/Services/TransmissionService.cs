using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class TransmissionService : IService<Transmission>, ITransmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public async Task AddAsync(Transmission transmission)
        {
            _unitOfWork.Transmission.Add(transmission);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Transmission transmission)
        {
            _unitOfWork.Transmission.Delete(transmission);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Transmission>> GetAllAsync()
        {
            IEnumerable<Transmission> transmissions = await _unitOfWork.Transmission.GetAllAsync();
            return transmissions;
        }

        public async Task<Transmission> GetByIdAsync(int id)
        {
            Transmission transmission = await _unitOfWork.Transmission.GetByIdAsync(id);
            return transmission;
        }

        public async Task UpdateAsync(Transmission transmission)
        {
            _unitOfWork.Transmission.Update(transmission);
            await _unitOfWork.SaveAsync();
        }
    }
}
