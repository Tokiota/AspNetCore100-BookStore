namespace Tokiota.BookStore.Domains.UseCases.FindAuthors
{
    using Core;

    public class FindAuthorsRequest : RequestUseCaseCore
    {
        public string Search { get; set; }
    }
}
