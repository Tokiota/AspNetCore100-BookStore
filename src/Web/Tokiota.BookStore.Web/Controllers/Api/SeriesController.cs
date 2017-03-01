namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Domains.UOW;
    using Entities;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;

    [Route("api/[controller]")]
    public class SeriesController : Controller
    {
        private readonly ILibraryUOW libraryUoW;

        public SeriesController(ILibraryUOW libraryUoW)
        {
            this.libraryUoW = libraryUoW;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Serie> Get()
        {
            return this.libraryUoW.GetSeries();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Serie Get(Guid id)
        {
            return this.libraryUoW.GetSerie(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Serie serie)
        {
            if (serie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                this.libraryUoW.CreateSerie(serie);
                Response.StatusCode = (int)HttpStatusCode.Created;

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Serie Serie)
        {
            if (id == null || id == Guid.Empty || Serie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                this.libraryUoW.UpdateSerie(id, Serie);
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
                this.libraryUoW.RemoveSerie(id);
                Response.StatusCode = (int)HttpStatusCode.Accepted;

            }
        }
    }
}
