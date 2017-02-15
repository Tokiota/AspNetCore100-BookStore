using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Domains.Core;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Domains
{
    public interface IBookDomain : IDomainCore<Book>
    {
    }
}
