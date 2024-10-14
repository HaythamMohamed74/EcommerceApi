using Ecommerce.Data.Data.contexts;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications
{
    public interface ISpecification<TEntity>
    {

        public Expression<Func<TEntity, bool>> Criteria { get; set; }


        public List<Expression<Func<TEntity, object>>> Includes { get; set; }
    }
}


