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
    public class AuthorsController : Controller
    {
        private readonly ILibraryUOW libraryUoW;
        private readonly Adapter mapper;

        public AuthorsController(ILibraryUOW libraryUoW, Adapter mapper)
        {
            this.libraryUoW = libraryUoW;
            this.mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<AuthorDto> Get()
        {
            var authors = this.libraryUoW.GetAuthors();
            return this.mapper.Adapt<IEnumerable<AuthorDto>>(authors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public AuthorDto Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            else
            {
                var author = this.libraryUoW.GetAuthor(id);
                Response.StatusCode = (int)HttpStatusCode.Created;
                return this.mapper.Adapt<AuthorDto>(author);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AuthorDto author)
        {
            if (author == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var authorEntity = this.mapper.Adapt<Author>(author);
                this.libraryUoW.CreateAuthor(authorEntity);
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]AuthorDto author)
        {
            if (id == null || id == Guid.Empty || author == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var authorEntity = this.mapper.Adapt<Author>(author);
                this.libraryUoW.UpdateAuthor(id, authorEntity);
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
                this.libraryUoW.RemoveAuthor(id);
                Response.StatusCode = (int)HttpStatusCode.Accepted;

            }
        }
    }
}
