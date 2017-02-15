using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Context
{
    public interface IContext
    {
        List<Author> Authors { get; set; }
        List<Book> Books { get; set; }
        List<Serie> Series { get; set; }

    }
}
