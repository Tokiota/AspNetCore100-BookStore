namespace Tokiota.BookStore.Domains
{
    using Core;
    using Entities;
    using Repositories;
    public class AuthorDomain : DomainCore<Author>, IAuthorDomain
    {
        public AuthorDomain(IAuthorRepository repo) : base(repo)
        {
        }
    }
}
