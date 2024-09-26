using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IFuelRepository : IRepository<Fuel, int>
    {
        public Fuel Update(Fuel fuel);
    }
}
