using AutoMapper;
using BookartAPI.DTO;
using BookartAPI.Helpers;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookartAPI.Controllers
{
    
    public class BooksController : BaseApiController
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Author> _authorRepo;
        private readonly IMapper _mapper;
        private readonly IBookRepository ibookrepo;

        public BooksController(IGenericRepository<Book> bookRepo, IGenericRepository<Category> categoryRepo, IGenericRepository<Author> authorRepo, IMapper mapper, IBookRepository ibookrepo
            )
        {
            _bookRepo = bookRepo;
            _categoryRepo = categoryRepo;
            _authorRepo = authorRepo;
            _mapper = mapper;
            this.ibookrepo = ibookrepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<BookReturnToDto>>> GetAllBooks([FromQuery]BookSpecParams bookSpecParams
            )
        {

            var spec = new BooksWithCategoryAndAuthor(bookSpecParams);
            var countSpec = new BookWithFilterAndCounterSpecification(bookSpecParams);
            var totalItems = await _bookRepo.CountAsync(countSpec);
            var AllBooks = await _bookRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookReturnToDto>>(AllBooks);

            return Ok(new Pagination<BookReturnToDto>(bookSpecParams.PageIndex, bookSpecParams.PageSize, totalItems, data));
                
        }
        [HttpGet("latest")]
        public async Task<ActionResult<IReadOnlyList<BookReturnToDto>>> GetAllBookLatestInOrder()
        {

            // var books = await ibookrepo.GetLatestBookAsync();
            BookSpecParams homesort = new BookSpecParams();
            homesort.sort = "latestFirst";



            
            var spec = new BooksWithCategoryAndAuthor(homesort);
            var books = await _bookRepo.ListAsync(spec);
            /*return books.Select(book => new BookReturnToDto
            {
                Id = book.Id,
                BookName = book.BookName,
                Description = book.Description,
                Price = book.Price,
                PictureUrl = book.PictureUrl,
                CategoryName = book.CategoryName.CategoryName.ToString(),
                BookAuthor = book.BookAuthor.AuthorName
            }).ToList();*/
            var data = _mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookReturnToDto>>(books).Take(3);
            
            return Ok(data);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookReturnToDto>> GetBook(int id)
        {
            var spec = new BooksWithCategoryAndAuthor(id);
            var book =  await _bookRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Book, BookReturnToDto>(book);
        }

        [HttpGet("Authors")]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetAllAuthors() {
            return Ok(await _authorRepo.ListAllAsync());
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetAllCategories() {
            return Ok(await _categoryRepo.ListAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<BookReturnToDto>> SellBook(BookReturnToDto uploadData)
        {
            
            return Ok();
        }
    }
}
