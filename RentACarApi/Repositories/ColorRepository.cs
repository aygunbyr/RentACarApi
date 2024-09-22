using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly ApplicationDbContext _db;
        public ColorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
