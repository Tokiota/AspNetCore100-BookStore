namespace Tokiota.BookStore.Domains
{
    using Core;
    using Entities;
    using Repositories;
    public class BookDomain : DomainCore<Book>, IBookDomain
    {
        public BookDomain(IBookRepository repo) : base(repo)
        {
        }
    }
}
