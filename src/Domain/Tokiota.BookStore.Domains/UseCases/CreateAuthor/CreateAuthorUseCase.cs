using System;

namespace Tokiota.BookStore.Domains.UseCases.CreateAuthor
{
    using System.Threading.Tasks;
    using Core;
    using Entities;
    using XCutting;

    public class CreateAuthorUseCase : UseCaseCore<CreateAuthorRequest, CreateAuthorResponse>
    {
        public CreateAuthorUseCase(ILibraryUoW uow) : base(uow) { }

        public override async Task<CreateAuthorResponse> Handle(CreateAuthorRequest request)
        {
            var response = new CreateAuthorResponse();
            var author = MapFromRequestToEntity(request);
            await UoW.AuthorRepository.Create(author);
            await UoW.SaveChanges();
            response.Response = Enums.Responses.eResponseType.Ok;
            return response;
        }

        private Author MapFromRequestToEntity(CreateAuthorRequest request)
        {
            var author = new Author()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Born = request.Born,
                Photo = request.Photo
            };

            return author;
        }
    }
}
