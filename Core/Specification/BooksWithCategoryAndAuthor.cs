using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BooksWithCategoryAndAuthor : BaseSpecification<Book>
    {
        public BooksWithCategoryAndAuthor()
        {
            AddInclude(x => x.CategoryName);
            AddInclude(x => x.BookAuthor);
        }

        public BooksWithCategoryAndAuthor(int id) : 
            base(x=>x.Id == id)
        {
            AddInclude(x => x.CategoryName);
            AddInclude(x => x.BookAuthor);
        }
    }
}
