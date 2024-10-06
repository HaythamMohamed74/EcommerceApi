using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IGenericRepository<TEntity,TKey>where TEntity : BaseEntity<TKey>
    {
        
        Task <TEntity> GetByIdAsync(TKey id);


        Task <IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllQueryable();

        Task  AddEntityAsync(TEntity entity);

        void UpdateEntityAsync(TEntity entity);
        
        void  DeleteEntityAsync(TEntity entity);
        
    }
}
