using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;
using RentACarApi.Services.Interfaces;

namespace RentACarApi.Services
{
    public class ColorService : IService<Color>, IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
        public async Task AddAsync(Color color)
        {
            _unitOfWork.Color.Add(color);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Color color)
        {
            _unitOfWork.Color.Delete(color);
            await _unitOfWork.SaveAsync();
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

        public async Task UpdateAsync(Color color)
        {
            _unitOfWork.Color.Update(color);
            await _unitOfWork.SaveAsync();
        }
    }
}
