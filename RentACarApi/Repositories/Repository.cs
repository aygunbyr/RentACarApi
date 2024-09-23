using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding entity", ex);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting entity", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving entities", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                T entity = await dbSet.FindAsync(id);
                if(entity == null)
                {
                    throw new KeyNotFoundException($"Entity with id {id} not found.");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving entity with id {id}", ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity", ex);
            }
        }
    }
}
