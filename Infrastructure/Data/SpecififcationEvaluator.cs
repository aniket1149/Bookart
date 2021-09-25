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
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query; 
        }
    }
}
