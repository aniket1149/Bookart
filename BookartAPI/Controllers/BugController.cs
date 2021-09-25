using BookartAPI.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookartAPI.Controllers
{
    public class BugController: BaseApiController
    {
        private readonly BookStoreContext _context;

        public BugController(BookStoreContext context)
        {
           
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound() {
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Books.Find(420000);

            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }


    }

}
