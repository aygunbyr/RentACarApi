using RentACarApi.Data;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICarRepository Car { get; private set; }

        public IColorRepository Color { get; private set; }

        public IFuelRepository Fuel { get; private set; }

        public ITransmissionRepository Transmission { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Car = new CarRepository(_db);
            Color = new ColorRepository(_db);
            Fuel = new FuelRepository(_db);
            Transmission = new TransmissionRepository(_db);
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
