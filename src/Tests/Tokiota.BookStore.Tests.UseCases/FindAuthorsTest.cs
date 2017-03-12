using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Domains.UseCases.FindAuthors;
using Tokiota.BookStore.Entities;
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
    public class FindAuthorsTest
    {
        private FindAuthorsRequest _request;
        private FindAuthorsUseCase _useCase;
        private FindAuthorsResponse _response;
        private readonly ILibraryUoW _unitOfWork;
        private readonly ContextFactory _factory;

        public FindAuthorsTest()
        {
            _factory = new ContextFactory();
            _factory.Initialize();
            _unitOfWork = _factory.Uow;

            _useCase = new FindAuthorsUseCase(_unitOfWork);
        }


        [Fact]
        public void FindAuthorsBySearch()
        {
            var expected = new FindAuthorsResponse()
            {
                Authors = new List<Author>()
                {
                    new Author() { Id = Guid.Parse("fac93f1e-ff28-49db-b234-13c9a5df2334")}
                }
            };
            this.Given(x => x.AnAuthorsRequestedByTheClient())
                .When(x => x.FindAuthors())
                .Then(x => x.IFindAuthors(expected))
                .BDDfy();
        }

        #region Given

        public void AnAuthorsRequestedByTheClient()
        {
            _request = new FindAuthorsRequest()
            {
                Search = "S"
            };
        }

        #endregion Given

        #region When 

        public async Task FindAuthors()
        {
            _response = await _useCase.Handle(_request);
        }

        #endregion When 

        #region Then

        public void IFindAuthors(FindAuthorsResponse expected)
        {
            _response.Should().NotBeNull();
            _response.IsValid.Should().BeTrue();

            _response.Authors.Count.Should().Be(expected.Authors.Count);
            _response.Authors.First().Id.Should().Be(expected.Authors.First().Id);
        }

        #endregion Then

    }
}
