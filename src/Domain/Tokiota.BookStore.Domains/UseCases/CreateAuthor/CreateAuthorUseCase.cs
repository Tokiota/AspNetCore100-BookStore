namespace Tokiota.BookStore.Domains.UseCases.CreateAuthor
{
    using Core;
    using Entities;
    using XCutting;

    public class CreateAuthorUseCase : UseCaseCore<CreateAuthorRequest, CreateAuthorResponse>
    {
        public CreateAuthorUseCase(ILibraryUoW uow) : base(uow) { }

        public override CreateAuthorResponse Handle(CreateAuthorRequest request)
        {
            var response = new CreateAuthorResponse();
            var author = MapFromRequestToEntity(request);
            UoW.AuthorRepository.Create(author);

            response.Response = Enums.Responses.eResponseType.Ok;
            return response;
        }

        public Author MapFromRequestToEntity(CreateAuthorRequest request)
        {
            var author = new Author()
            {
                Name = request.Name,
                LastName = request.LastName,
                Born = request.Born,
                Photo = request.Photo
            };

            return author;
        }
    }
}
