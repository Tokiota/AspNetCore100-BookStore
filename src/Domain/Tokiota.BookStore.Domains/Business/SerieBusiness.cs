using System;
using System.Collections.Generic;
using System.Text;

namespace Tokiota.BookStore.Domains.Business
{
    using Core;
    using System.Threading.Tasks;
    using Tokiota.BookStore.Entities;
    using Tokiota.BookStore.XCutting;

    public class SerieBusiness : BusinessCore<Serie, Guid>, ISerieBusiness
    {
        public SerieBusiness(ILibraryUoW uow) : base(uow, uow.SerieRepository)
        {
        }

        public Task<List<Serie>> GetByAuthor(Guid authorId)
        {
            return this.Repository.Get(b => b.AuthorId == authorId);
        }
    }
}
