namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Domains.UOW;
    using Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;

    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly ILibraryUOW libraryUoW;

        public AuthorsController(ILibraryUOW libraryUoW)
        {
            this.libraryUoW = libraryUoW;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return this.libraryUoW.GetAuthorsComplete();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get(Guid id)
        {
            return this.libraryUoW.GetAuthor(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Author author)
        {
            if (author == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else this.libraryUoW.CreateAuthor(author);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Author author)
        {
            if (id == null || id == Guid.Empty || author == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Accepted;
            }
            else this.libraryUoW.UpdateAuthor(id, author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                Response.StatusCode = (int)HttpStatusCode.Accepted;
            }
            else this.libraryUoW.RemoveAuthor(id);
        }
    }
}
