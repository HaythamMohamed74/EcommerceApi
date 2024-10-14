using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications
{
    public class BaseSpcefication<TEntity> : ISpecification<TEntity>
    {

        public BaseSpcefication()
        {
            
        }
        public BaseSpcefication(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();


       protected void AddIncludes(Expression<Func<TEntity, object>> includesExp)
        {
            Includes.Add(includesExp);
        }

    }
}
