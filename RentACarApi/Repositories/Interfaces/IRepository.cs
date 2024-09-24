using RentACarApi.Dtos;
using System.Linq.Expressions;

namespace RentACarApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public T Add(T entity);
        public T Delete(T entity);
    }
}
