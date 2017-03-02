namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Core;
    using Domains.Business.Core;
    using Entities;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class AuthorsController : ApiCore<Author, AuthorDto>
    {
        public AuthorsController(IBusinessCoreGuid<Author> business, Adapter mapper) : base(business, mapper) { }
    }
}
