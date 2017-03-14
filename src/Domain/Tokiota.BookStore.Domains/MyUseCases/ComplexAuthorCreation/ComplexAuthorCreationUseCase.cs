using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Domains.UseCases.Core;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.XCutting;

namespace Tokiota.BookStore.Domains.MyUseCases.ComplexAuthorCreation
{
    public class ComplexAuthorCreationUseCase : UseCaseCore<ComplexAuthorCreationRequest, ComplexAuthorCreationResponse>
    {
        public ComplexAuthorCreationUseCase(ILibraryUoW uow) : base(uow)
        {
        }

        public override async Task<ComplexAuthorCreationResponse> Handle(ComplexAuthorCreationRequest request)
        {
            var response = new ComplexAuthorCreationResponse();

            if (this.RequestIsValid(request))
            {
                var author = this.MapToServer(request);
                await UoW.AuthorRepository.Create(author);
                await UoW.SaveChanges();
                response.Response = Enums.Responses.eResponseType.Ok;
            }
            else
            {
                response.Response = Enums.Responses.eResponseType.CreationError;
            }

            return response;
        }

        private Author MapToServer(ComplexAuthorCreationRequest request)
        {
            return new Author()
            {
                Id =  Guid.NewGuid(),
                Name = request.Name
            };
        }

        private bool RequestIsValid(ComplexAuthorCreationRequest request)
        {
            return request != null && !string.IsNullOrWhiteSpace(request.Name);
        }
    }
}
