using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Domains.Business
{
    using Core;
    public interface IBookBusiness : IBusinessCore<Book, Guid>
    {
        Task<List<Book>> GetByAuthor(Guid authorId);
    }
}