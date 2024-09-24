using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface ITransmissionRepository : IRepository<Transmission>
    {
        public Transmission Update(Transmission transmission);
    }
}
