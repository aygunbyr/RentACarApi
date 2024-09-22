using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class TransmissionService : ITransmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public void Add(Transmission transmission)
        {
            _unitOfWork.Transmission.Add(transmission);
        }

        public void Delete(Transmission transmission)
        {
            _unitOfWork.Transmission.Delete(transmission);
        }

        public IEnumerable<Transmission> GetAll()
        {
            IEnumerable<Transmission> transmissions = _unitOfWork.Transmission.GetAll();
            return transmissions;
        }

        public Transmission GetById(int id)
        {
            Transmission transmission = _unitOfWork.Transmission.GetById(id);
            return transmission;
        }

        public void Update(Transmission transmission)
        {
            _unitOfWork.Transmission.Update(transmission);
        }
    }
}
