using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Domains.Business
{
    using Core;
    public interface ISerieBusiness : IBusinessCore<Serie, Guid>
    {
        Task<List<Serie>> GetByAuthor(Guid authorId);
    }
}