using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications
{
    public static  class SpecificationEvaluator<TEntity, TKey>  where TEntity : BaseEntity<TKey>
    {
        
        public static IQueryable<TEntity> BuildQuery( IQueryable<TEntity> inputQuery ,ISpecification<TEntity>spec)
        {
            //products.Where(p => p.Name.Contains(""));
            var query =inputQuery;  //storeDBContext.Set<TEntity>()
            if (spec.Criteria is not null)
            {
              query= query.Where(spec.Criteria);    //.where(exp)
            }
           

            if (spec.Includes is not null)
            {
                query = spec.Includes.Aggregate(query, (currentQuery, includeExp) => currentQuery.Include(includeExp));
            }
            if (spec.OrderBy is not null)
            {

                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.IsPagination&&spec.Skip.HasValue&&spec.Take.HasValue)
            {
                    query = query
              .Skip((spec.Skip.Value - 1) * spec.Take.Value)
              .Take(spec.Take.Value);
            }


            return query;
        }



    }
    
    
}
