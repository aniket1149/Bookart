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
        public BooksWithCategoryAndAuthor(BookSpecParams bookSpecParams)
                 : base(x =>
                  (string.IsNullOrEmpty(bookSpecParams.search) || x.BookName.ToLower().Contains(bookSpecParams.search) || x.Description.ToLower().Contains(bookSpecParams.search) || x.BookAuthor.AuthorName.ToLower().Contains(bookSpecParams.search))
                 &&
                 (!bookSpecParams.categoryId.HasValue || x.CategoryId== bookSpecParams.categoryId) &&
                 (!bookSpecParams.authorId.HasValue || x.BookAuthorId== bookSpecParams.authorId)
            )
        {
            AddOrderBy(x => x.BookName);
            AddInclude(x => x.CategoryName);
            AddInclude(x => x.BookAuthor);
            ApplyPaging(bookSpecParams.PageSize * (bookSpecParams.PageIndex - 1), bookSpecParams.PageSize);
            if (!string.IsNullOrEmpty(bookSpecParams.sort)) {
                switch (bookSpecParams.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.BookName);
                        break;
                }
            }
        }

        public BooksWithCategoryAndAuthor(int id) : 
            base(x=>x.Id == id)
        {
            AddInclude(x => x.CategoryName);
            AddInclude(x => x.BookAuthor);
        }
    }
}
