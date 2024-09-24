using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class FuelRepository : Repository<Fuel>, IFuelRepository
    {
        private readonly ApplicationDbContext _db;
        public FuelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Fuel Update(Fuel fuel)
        {
            try
            {
                var existingFuel = _db.Fuels.FirstOrDefault(x => x.Id == fuel.Id);
                if (existingFuel == null)
                {
                    throw new KeyNotFoundException($"Car with id {fuel.Id} not found");
                }
                existingFuel.Name = fuel.Name;
                _db.Fuels.Update(existingFuel);
                return existingFuel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity", ex);
            }
        }
    }
}
