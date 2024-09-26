using RentACarApi.Models.Dtos;
using RentACarApi.Models;
using System.Linq.Expressions;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : Entity<TId>, new()
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(TId id);
        public TEntity Add(TEntity entity);
        public TEntity Delete(TEntity entity);
    }
}
