using Ecommerce.Data.Data.contexts;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDBContext _storeDBContext;

        public GenericRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }
        public async Task AddEntityAsync(TEntity entity)
        {
              await  _storeDBContext.Set<TEntity>().AddAsync(entity);
        }

        public void DeleteEntityAsync(TEntity entity)
        {
            _storeDBContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _storeDBContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public  IQueryable<TEntity> GetAllQueryable()
        {
            return  _storeDBContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
         return  await _storeDBContext.Set<TEntity>().FindAsync(id);
        }

        public void UpdateEntityAsync(TEntity entity)
        {
            _storeDBContext.Set<TEntity>().Update(entity);
        }
    }
}
