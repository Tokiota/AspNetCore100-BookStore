namespace Tokiota.BookStore.Domains.UseCases.CreateAuthor
{
    using Core;

    public class CreateAuthorRequest : RequestUseCaseCore
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Born { get; set; }
        public string Photo { get; set; }
    }
}
