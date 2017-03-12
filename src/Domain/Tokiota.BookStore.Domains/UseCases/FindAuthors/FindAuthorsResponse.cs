namespace Tokiota.BookStore.Domains.UseCases.FindAuthors
{
    using System.Collections.Generic;
    using Core;
    using Entities;

    public class FindAuthorsResponse : ResponseUseCaseCore
    {
        public List<Author> Authors { get; set; }
    }
}
