using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Domains.MyUseCases.ComplexAuthorCreation;
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

    [Collection("UseCases"), Story(AsA = "user of the application",
            IWant = "to create an author complexly",
            SoThat = "Author is created"
        )]
    public class ComplexAuthorCreationUseCaseTests
    {
        private ComplexAuthorCreationRequest _request;
        private ComplexAuthorCreationUseCase _useCase;
        private ComplexAuthorCreationResponse _response;

        public ComplexAuthorCreationUseCaseTests()
        {
            var factory = new ContextFactory();
            _useCase = new ComplexAuthorCreationUseCase(factory.Uow);
        }


        [Fact]
        public void CreateBasicAuthor()
        {
            var expected = new ComplexAuthorCreationResponse()
            {
                Response = Enums.Responses.eResponseType.Ok
            };

            this.Given(x => x.AnAuthorWillingToBeCreate())
                .When(x => x.CallAuthorCreation())
                .Then(x => x.ICreateAnAuthor(expected))
                .BDDfy();
        }

        #region Given

        public void AnAuthorWillingToBeCreate()
        {
            _request = new ComplexAuthorCreationRequest()
            {
                Name = "Gurpegui"
            };
        }

        #endregion Given

        #region When 

        public async Task CallAuthorCreation()
        {
            _response = await _useCase.Handle(_request);
        }

        #endregion When 

        #region Then

        public void ICreateAnAuthor(ComplexAuthorCreationResponse expected)
        {
            _response.Should().NotBeNull();
            _response.IsValid.Should().Be(expected.IsValid);
            _response.Response.Should().Be(expected.Response);
        }

        #endregion Then

    }
}
