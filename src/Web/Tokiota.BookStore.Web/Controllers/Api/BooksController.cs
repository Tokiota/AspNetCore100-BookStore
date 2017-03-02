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
        public BooksController(IBusinessCoreGuid<Book> business, Adapter mapper) : base(business, mapper) { }
    }
}
