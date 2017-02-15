using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Context
{
    public class Context
    {
        public Context()
        {
        }

        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
        public List<Serie> Series { get; set; }

    }
}
