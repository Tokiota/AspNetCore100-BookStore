namespace Tokiota.BookStore.Entities
{
    using Core;
    using System;
    using System.Collections.Generic;

    public class Author : EntityCore<Guid>
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public string Name { get; set; }
        public string LastName { get; set; }

        public int Born { get; set; }
        public List<Book> Books { get; set; }


    }
}
