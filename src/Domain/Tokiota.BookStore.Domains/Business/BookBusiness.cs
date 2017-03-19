using System;
using System.Collections.Generic;
using System.Text;

namespace Tokiota.BookStore.Domains.Business
{
    using Core;
    using System.Threading.Tasks;
    using Tokiota.BookStore.Entities;
    using Tokiota.BookStore.XCutting;

    public class BookBusiness : BusinessCore<Book, Guid>, IBookBusiness
    {
        public BookBusiness(ILibraryUoW uow) : base(uow, uow.BookRepository)
        {
        }

        public Task<List<Book>> GetByAuthor(Guid authorId)
        {
            return this.Repository.Get(b => b.AuthorId == authorId);
        }
    }
}
