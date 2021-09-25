using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    class SpecififcationEvaluator<TypeEntity> where TypeEntity : BaseEntity
    {
        public static IQueryable<TypeEntity> GetQuery(IQueryable<TypeEntity> inputQuery, ISpecification<TypeEntity> spec) {
            var query = inputQuery;
            if (spec.Criteria != null) {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }//always should be at end
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query; 
        }
    }
}
