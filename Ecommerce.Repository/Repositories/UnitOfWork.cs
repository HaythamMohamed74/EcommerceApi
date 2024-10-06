using Ecommerce.Data.Data.contexts;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly StoreDBContext _storeDBContext;
        private readonly Dictionary<string,object>repositories = new();

        public UnitOfWork(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }

        public void Dispose()
        {
            _storeDBContext.Dispose();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            if (!repositories.ContainsKey(typeName))
            {
                var repo = new GenericRepository<TEntity, TKey>(_storeDBContext);   
                repositories.Add(typeName, repo);
            }
            return (IGenericRepository<TEntity,TKey>)repositories[typeName];
        }

        public async Task<int> SaveChanges()
        {
         return  await  _storeDBContext.SaveChangesAsync();
        }
    }
}
