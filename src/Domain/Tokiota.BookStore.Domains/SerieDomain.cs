namespace Tokiota.BookStore.Domains
{
    using Core;
    using Entities;
    using Repositories;
    public class SerieDomain : DomainCore<Serie>, ISerieDomain
    {
        public SerieDomain(ISerieRepository repo) : base(repo)
        {
        }

    }
}
