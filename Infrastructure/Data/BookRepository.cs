using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(p => p.BookAuthor)
                .Include(p => p.CategoryName)
                .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync()
        {
            return await _context.Books
                .Include(p=>p.BookAuthor)
                .Include(p=>p.CategoryName)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Category>> GetCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
