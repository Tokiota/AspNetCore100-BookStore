namespace Tokiota.BookStore.Entities
{
    using Core;
    using System;
    using System.Collections.Generic;

    public class Serie : EntityCore<Guid>
    {
        public Serie()
        {
        }

        public string Name { get; set; }
        public string Photo { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Book> Books { get; set; }
    }
}
