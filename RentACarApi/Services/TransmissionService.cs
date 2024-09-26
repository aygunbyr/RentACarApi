using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class TransmissionService : IService<Transmission, int>, ITransmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public async Task<Transmission> AddAsync(Transmission transmission)
        {
            Transmission addedTransmission = _unitOfWork.Transmission.Add(transmission);
            await _unitOfWork.SaveAsync();
            return addedTransmission;
        }

        public async Task<Transmission> DeleteAsync(Transmission transmission)
        {
            Transmission deletedTransmission = _unitOfWork.Transmission.Delete(transmission);
            await _unitOfWork.SaveAsync();
            return deletedTransmission;
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

        public async Task<Transmission> UpdateAsync(Transmission transmission)
        {
            Transmission updatedTransmission = _unitOfWork.Transmission.Update(transmission);
            await _unitOfWork.SaveAsync();
            return updatedTransmission;
        }
    }
}
