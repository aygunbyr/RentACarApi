using Microsoft.EntityFrameworkCore;
using RentACarApi.Data;
using RentACarApi.Models;
using RentACarApi.Repositories.Interfaces;

namespace RentACarApi.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : Entity<TId>, new()
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<TEntity> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding entity", ex);
            }
        }

        public TEntity Delete(TEntity entity)
        {
            try
            {
                dbSet.Remove(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting entity", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
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

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            try
            {
                TEntity entity = await dbSet.FindAsync(id);
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
    }
}
