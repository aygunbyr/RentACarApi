using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface IFuelService
    {
        IEnumerable<Fuel> GetAll();
        Fuel GetById(int id);
        void Add(Fuel fuel);
        void Update(Fuel fuel);
        void Delete(Fuel fuel);
    }
}
