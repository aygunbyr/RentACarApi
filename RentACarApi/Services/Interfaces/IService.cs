using RentACarApi.Models;

namespace RentACarApi.Services.Interfaces
{
    public interface IService<TEntity, TId> where TEntity : Entity<TId>, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
