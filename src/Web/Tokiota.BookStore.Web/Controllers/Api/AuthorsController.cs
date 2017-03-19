using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Core;
    using Domains.Business.Core;
    using Entities;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tokiota.BookStore.Domains.Business;

    [Route("api/[controller]")]
    public class AuthorsController : ApiCore<Author, AuthorDto>
    {
        private readonly IBookBusiness bookBusiness;
        private readonly ISerieBusiness serieBusiness;

        public AuthorsController(IBusinessCoreGuid<Author> business, Adapter mapper, IDistributedCache redis, 
                                    IBookBusiness bookBusiness, ISerieBusiness serieBusiness) 
            : base("Author", business, mapper, redis)
        {
            this.bookBusiness = bookBusiness;
            this.serieBusiness = serieBusiness;
        }


        [HttpGet("{id}/Books")]
        public async Task<IActionResult> GetBooks(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var entity = await this.bookBusiness.GetByAuthor(id);
                if (entity != null)
                {
                    var mappedEntity = Mapper.Adapt<IEnumerable<BookDto>>(entity);
                    return Ok(mappedEntity);
                }
            }

            return BadRequest();
        }
        [HttpGet("{id}/Series")]
        public async Task<IActionResult> GetSeries(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var entity = await this.serieBusiness.GetByAuthor(id);
                if (entity != null)
                {
                    var mappedEntity = Mapper.Adapt<IEnumerable<SerieDto>>(entity);
                    return Ok(mappedEntity);
                }
            }

            return BadRequest();
        }
    }
}
