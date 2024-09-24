namespace RentACarApi.Repositories.Interfaces
{
    public interface IRepository<Entity>
    {
        public Task<IEnumerable<Entity>> GetAllAsync();
        public Task<Entity> GetByIdAsync(int id);
        public void Add(Entity entity);
        public void Update(Entity entity);
        public void Delete(Entity entity);
    }
}
