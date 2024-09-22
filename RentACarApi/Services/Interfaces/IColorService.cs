using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface IColorService
    {
        IEnumerable<Color> GetAll();
        Color GetById(int id);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
