using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Repositories.UoW;
using Tokiota.BookStore.Tests.UseCases.Common;
using Tokiota.BookStore.XCutting;

namespace Tokiota.BookStore.Tests.UseCases
{
    using System.Threading.Tasks;
    using Domains.UseCases.CreateAuthor;
    using TestStack.BDDfy;
    using Web.Models;
    using Xunit;

    [Collection("UseCases"), Story(AsA = "User of the application",
            IWant = "To create an author",
            SoThat = "Author is created"
        )]
    public class AuthorCreationTest
    {
        private CreateAuthorRequest _request;
        private CreateAuthorUseCase _useCase;
        private CreateAuthorResponse _response;
        private readonly ILibraryUoW _unitOfWork;
        private readonly ContextFactory _factory;

        public AuthorCreationTest()
        {
            _factory =  new ContextFactory();
            _factory.Initialize().Wait();
            _unitOfWork = _factory.Uow;

            _useCase = new CreateAuthorUseCase(_unitOfWork);
        }


        [Fact]
        public void CreateAuthorTest()
        {
            this.Given(x => x.AnAuthorGivenByTheApplicationUser())
                .When(x => x.CreateAnAuthor())
                .Then(x => x.ICreateAnAuthor())
                .BDDfy();
        }

        #region Given

        public void AnAuthorGivenByTheApplicationUser()
        {
            _request = new CreateAuthorRequest()
            {
                Name = "author name",
                LastName = " author last name",
                Born = 1999,
                Photo = "this is an url"
            };
        }

        #endregion Given

        #region When 

        public async Task CreateAnAuthor()
        {
            _response = await _useCase.Handle(_request);
        }

        #endregion When 

        #region Then

        public void ICreateAnAuthor()
        {
            _response.Should().NotBeNull();
            _response.IsValid.Should().BeTrue();
        }

        #endregion Then
    }
}
