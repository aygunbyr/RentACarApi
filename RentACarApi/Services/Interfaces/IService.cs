namespace RentACarApi.Services.Interfaces
{
    public interface IService<Entity>
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task AddAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task UpdateAsync(Entity entity);
    }
}
