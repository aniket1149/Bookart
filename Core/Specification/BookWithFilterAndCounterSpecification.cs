using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BookWithFilterAndCounterSpecification :BaseSpecification<Book>
    {
        public BookWithFilterAndCounterSpecification(BookSpecParams bookSpecParams) 
            : base(x =>
            (string.IsNullOrEmpty(bookSpecParams.search) || x.BookName.ToLower().Contains(bookSpecParams.search)) &&
                 (!bookSpecParams.categoryId.HasValue || x.CategoryId == bookSpecParams.categoryId) &&
                 (!bookSpecParams.authorId.HasValue || x.BookAuthorId == bookSpecParams.authorId))
        {
        }
    }
}
