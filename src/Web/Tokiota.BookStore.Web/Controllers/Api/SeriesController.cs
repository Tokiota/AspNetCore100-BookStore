namespace Tokiota.BookStore.Web.Controllers.Api
{
    using Core;
    using Domains.Business.Core;
    using Entities;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    public class SeriesController : ApiCore<Serie, SerieDto>
    {
        public SeriesController(IBusinessCoreGuid<Serie> business, Adapter mapper) : base(business, mapper) { }
    }
}
