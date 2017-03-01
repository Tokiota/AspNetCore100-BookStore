namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Domains.UOW;
    using Entities;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Net;

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly ILibraryUOW libraryUoW;
        private readonly Adapter mapper;

        public BooksController(ILibraryUOW libraryUoW, Adapter mapper)
        {
            this.libraryUoW = libraryUoW;
            this.mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            var books = this.libraryUoW.GetBooksComplete();
            return this.mapper.Adapt<IEnumerable<BookDto>>(books);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BookDto Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            else
            {
                var book = this.libraryUoW.GetBook(id);
                Response.StatusCode = (int)HttpStatusCode.Created;
                return this.mapper.Adapt<BookDto>(book);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BookDto book)
        {
            if (book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var bookEntity = this.mapper.Adapt<Book>(book);
                this.libraryUoW.CreateBook(bookEntity);
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]BookDto book)
        {
            if (id == null || id == Guid.Empty || book == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var bookEntity = this.mapper.Adapt<Book>(book);
                this.libraryUoW.UpdateBook(id, bookEntity);
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
