using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BooksLatestOrderByLastDateCreation : BaseSpecification<Book>
    {
        public BooksLatestOrderByLastDateCreation()
        {
            AddInclude(x => x.CategoryName);
            
        }
    }
}
