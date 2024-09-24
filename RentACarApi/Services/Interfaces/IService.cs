namespace RentACarApi.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
