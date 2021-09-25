using Core.Entities;
using Core.Interface;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var AllBooks = await _repo.GetBooksAsync();

            return Ok(AllBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _repo.GetBookByIdAsync(id);
        }

        [HttpGet("Authors")]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetAllAuthors() {
            return Ok(await _repo.GetAuthorsAsync());
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetAllCategories() {
            return Ok(await _repo.GetCategoryAsync());
        }
    }
}
