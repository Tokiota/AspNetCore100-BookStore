namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Domains.UOW;
    using Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly ILibraryUOW libraryUoW;

        public BooksController(ILibraryUOW libraryUoW)
        {
            this.libraryUoW = libraryUoW;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return this.libraryUoW.GetBooksComplete();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(Guid id)
        {
            return this.libraryUoW.GetBook(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Book book)
        {
            if (book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                this.libraryUoW.CreateBook(book);
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Book Book)
        {
            if (id == null || id == Guid.Empty || Book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                this.libraryUoW.UpdateBook(id, Book);
                Response.StatusCode = (int)HttpStatusCode.Accepted;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                this.libraryUoW.RemoveBook(id);
                Response.StatusCode = (int)HttpStatusCode.Accepted;
            }
        }
    }
}
