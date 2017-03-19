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

    [Route("api/[controller]")]
    public class BooksController : ApiCore<Book, BookDto>
    {
        public BooksController(IBusinessCoreGuid<Book> business, Adapter mapper) : base("Book", business, mapper) { }
    }
}
