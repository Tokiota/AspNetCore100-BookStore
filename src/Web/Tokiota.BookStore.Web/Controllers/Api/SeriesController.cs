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
    public class SeriesController : Controller
    {
        private readonly ILibraryUOW libraryUoW;
        private readonly Adapter mapper;

        public SeriesController(ILibraryUOW libraryUoW, Adapter mapper)
        {
            this.libraryUoW = libraryUoW;
            this.mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SerieDto> Get()
        {
            var series = this.libraryUoW.GetSeries();
            return this.mapper.Adapt<IEnumerable<SerieDto>>(series);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SerieDto Get(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            else
            {
                var serie = this.libraryUoW.GetSerie(id);
                Response.StatusCode = (int)HttpStatusCode.Created;
                return this.mapper.Adapt<SerieDto>(serie);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]SerieDto serie)
        {
            if (serie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var serieEntity = this.mapper.Adapt<Serie>(serie);
                this.libraryUoW.CreateSerie(serieEntity);
                Response.StatusCode = (int)HttpStatusCode.Created;

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]SerieDto serie)
        {
            if (id == null || id == Guid.Empty || serie == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var serieEntity = this.mapper.Adapt<Serie>(serie);
                this.libraryUoW.UpdateSerie(id, serieEntity);
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
