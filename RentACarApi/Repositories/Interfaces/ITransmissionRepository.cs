using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface ITransmissionRepository : IRepository<Transmission, int>
    {
        public Transmission Update(Transmission transmission);
    }
}
