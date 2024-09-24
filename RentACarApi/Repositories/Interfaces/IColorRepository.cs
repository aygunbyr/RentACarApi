using RentACarApi.Models;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IColorRepository : IRepository<Color>
    {
        public Color Update(Color color);
    }
}
