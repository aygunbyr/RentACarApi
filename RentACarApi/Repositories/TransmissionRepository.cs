using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class TransmissionRepository : Repository<Transmission, int>, ITransmissionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransmissionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Transmission Update(Transmission transmission)
        {
            try
            {
                var existingTransmission = _db.Transmissions.FirstOrDefault(x => x.Id == transmission.Id);
                if (existingTransmission == null)
                {
                    throw new KeyNotFoundException($"Car with id {transmission.Id} not found");
                }
                existingTransmission.Name = transmission.Name;
                _db.Transmissions.Update(existingTransmission);
                return existingTransmission;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity", ex);
            }
        }
    }
}
