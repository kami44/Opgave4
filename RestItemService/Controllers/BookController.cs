using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Book;

namespace RestItemService.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static readonly List<Books> Book = new List<Books>()
        {
            new Books("stad", 299, "9780133594140", "Goodenough"),
            new Books("dsfkl",400,"9780133594141","Goodd")
        };

        // GET: api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Books>> Get()
        {
            return Book;
        }

        // GET: api/Book/5
        [HttpGet("{isbn13}")]
        public Books Get(string isbn13)
        {
            return Book.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Books value)
        {
            Book.Add(value);
        }

        // PUT: api/Book/5
        [HttpPut]
        [Route("{isbn13}")]
        public void Put(string isbn13, [FromBody] Books value)
        {
            Books book = Get(isbn13);
            if (Book != null)
            {
                book.Title = value.Title;
                book.Forfatter = value.Forfatter;
                book.Sidetal = value.Sidetal;
                book.Isbn13 = value.Isbn13;
            }
             
    }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Books book = Get(isbn13);
            Book.Remove(book);
        }
    }
}
