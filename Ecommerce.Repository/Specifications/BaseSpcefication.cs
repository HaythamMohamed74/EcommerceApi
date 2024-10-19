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
        // Get all
        public BaseSpcefication()
        {
            
        }
        //Get By id 
        public BaseSpcefication(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        

        public Expression<Func<TEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public Expression<Func<TEntity, object>> OrderBy { get ; set ; }
        public Expression<Func<TEntity, object>> OrderByDesc { get ; set ; }
        public int? Skip { get; set; }
        public int? Take { get; set; } 
        public bool IsPagination { get; set; } 

        protected void AddIncludes(Expression<Func<TEntity, object>> includesExp)
        {
            Includes.Add(includesExp);
        } 
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderExp)
        {
            OrderBy = orderExp;
        }   
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderExp)
        {
            OrderByDesc = orderExp;
        }
        protected void AddPagination(int? _skip,int? _take)
        {
            IsPagination=true;
            Skip= _skip;
             Take= _take;
        }




    }
}
