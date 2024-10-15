using Ecommerce.Data.Entities;
using Ecommerce.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IGenericRepository<TEntity,TKey>where TEntity : BaseEntity<TKey>
    {
        
        Task <TEntity> GetByIdAsync(ISpecification<TEntity>? specification);
        //Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> specification);


        Task <IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification);

        //Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> specification);
        IQueryable<TEntity> GetAllQueryable();

        Task  AddEntityAsync(TEntity entity);

        void UpdateEntityAsync(TEntity entity);
        
        void  DeleteEntityAsync(TEntity entity);
        
    }
}
