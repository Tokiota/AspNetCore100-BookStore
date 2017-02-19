namespace Tokiota.BookStore.Entities
{
    using Core;
    using System;
    public class Serie : EntityCore<Guid>
    {
        public Serie()
        {
        }

        public string Name { get; set; }
        public string Photo { get; set; }

        public Guid AuthorId { get; set; }
    }
}
