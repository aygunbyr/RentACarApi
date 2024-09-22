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
    }
}
