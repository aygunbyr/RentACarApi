using Microsoft.EntityFrameworkCore;
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

        public Color Update(Color color)
        {
            try
            {
                var existingColor = _db.Colors.FirstOrDefault(x => x.Id == color.Id);
                if (existingColor == null)
                {
                    throw new KeyNotFoundException($"Car with id {color.Id} not found");
                }
                existingColor.Name = color.Name;
                _db.Colors.Update(existingColor);
                return existingColor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity", ex);
            }
        }
    }
}
