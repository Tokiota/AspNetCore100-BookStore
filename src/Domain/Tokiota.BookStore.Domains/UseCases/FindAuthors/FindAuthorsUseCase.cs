using System.Collections.Generic;

namespace Tokiota.BookStore.Domains.UseCases.FindAuthors
{
    using System.Threading.Tasks;
    using Core;
    using Entities;
    using XCutting;

    public class FindAuthorsUseCase : UseCaseCore<FindAuthorsRequest, FindAuthorsResponse>
    {
        public FindAuthorsUseCase(ILibraryUoW uow) : base(uow) { }

        public override async Task<FindAuthorsResponse> Handle(FindAuthorsRequest request)
        {
            var response = new FindAuthorsResponse()
            {
                Authors = new List<Author>()
            };

            if (IsValid(request))
            {
                var authors = await UoW.AuthorRepository.Get(a => a.Name.Contains(request.Search));
                response.Authors = authors;
                response.Response = Enums.Responses.eResponseType.Ok;
            }

            return response;
        }

        private bool IsValid(FindAuthorsRequest request)
        {
            return !string.IsNullOrWhiteSpace(request.Search);
        }
    }
}
