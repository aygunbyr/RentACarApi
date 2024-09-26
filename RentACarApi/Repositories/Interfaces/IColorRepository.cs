using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IColorRepository : IRepository<Color, int>
    {
        public Color Update(Color color);
    }
}
