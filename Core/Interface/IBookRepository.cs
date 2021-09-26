using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IReadOnlyList<Book>> GetBooksAsync();
        Task<IReadOnlyList<Category>> GetCategoryAsync();
        Task<IReadOnlyList<Author>> GetAuthorsAsync();

        

    }
}
