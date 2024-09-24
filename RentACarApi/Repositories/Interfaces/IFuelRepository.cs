using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IFuelRepository : IRepository<Fuel>
    {
        public Fuel Update(Fuel fuel);
    }
}
