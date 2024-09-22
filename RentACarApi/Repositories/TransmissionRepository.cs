using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class TransmissionRepository : Repository<Transmission>, ITransmissionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransmissionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
