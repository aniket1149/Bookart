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
        public BooksController(IGenericRepository<Book> bookRepo, IGenericRepository<Category> categoryRepo, IGenericRepository<Author> authorRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _categoryRepo = categoryRepo;
            _authorRepo = authorRepo;
            _mapper = mapper;
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
    }
}
