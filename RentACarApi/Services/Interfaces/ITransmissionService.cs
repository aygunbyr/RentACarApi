using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface ITransmissionService
    {
        IEnumerable<Transmission> GetAll();
        Transmission GetById(int id);
        void Add(Transmission transmission);
        void Update(Transmission transmission);
        void Delete(Transmission transmission);
    }
}
