using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public void Add(Color color)
        {
            _unitOfWork.Color.Add(color);
        }

        public void Delete(Color color)
        {
            _unitOfWork.Color.Delete(color);
        }

        public IEnumerable<Color> GetAll()
        {
            IEnumerable<Color> colors = _unitOfWork.Color.GetAll();
            return colors;
        }

        public Color GetById(int id)
        {
            Color color = _unitOfWork.Color.GetById(id);
            return color;
        }

        public void Update(Color color)
        {
            _unitOfWork.Color.Update(color);
        }
    }
}
