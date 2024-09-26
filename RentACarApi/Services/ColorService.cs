using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class ColorService : IService<Color, int>, IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public async Task<Color> AddAsync(Color color)
        {
            Color addedColor = _unitOfWork.Color.Add(color);
            await _unitOfWork.SaveAsync();
            return addedColor;
        }

        public async Task<Color> DeleteAsync(Color color)
        {
            Color deletedColor = _unitOfWork.Color.Delete(color);
            await _unitOfWork.SaveAsync();
            return deletedColor;
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            IEnumerable<Color> colors = await _unitOfWork.Color.GetAllAsync();
            return colors;
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            Color color = await _unitOfWork.Color.GetByIdAsync(id);
            return color;
        }

        public async Task<Color> UpdateAsync(Color color)
        {
            Color updatedColor = _unitOfWork.Color.Update(color);
            await _unitOfWork.SaveAsync();
            return updatedColor;
        }
    }
}
