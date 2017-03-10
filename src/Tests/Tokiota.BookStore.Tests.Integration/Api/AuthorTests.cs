using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Web;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Tokiota.BookStore.Tests.Integration.Api
{
    public class AuthorTests 
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AuthorTests()
        {
            //_server = new TestServer(TestServer.CreateBuilder(null, app =>
            //{
            //    app.UsePrimeCheckerMiddleware();
            //},
            //services =>
            //{
            //    services.AddSingleton<IPrimeService, NegativePrimeService>();
            //    services.AddSingleton<IPrimeCheckerOptions>(_ => new AlternativePrimeCheckerOptions(_fixture.Path));
            //}));
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>().ConfigureServices(s =>
                {
                    s.AddEntityFrameworkSqlServer().AddDbContext<LibraryContext>(o =>o.UseInMemoryDatabase());
                })
            );


            //new WebHostBuilder()
            //       .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetAuthors()
        {
            // Act
            var response = await _client.GetAsync("/Api/Authors");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<List<Author>>(responseString);
            // Assert
            Assert.NotNull(authors);
            Assert.True(authors.Any());
        }

        [Fact]
        public async Task TestGetAuthorsAndGetAuthorSimon()
        {
            var author = await this.GetConcreteAuthorByName("Simon");
            // Assert
            Assert.NotNull(author);
            Assert.Equal("Simon", author.Name);
            Assert.Equal("Scarrow", author.LastName);
            Assert.Equal(1962, author.Born);
        }

        [Fact]
        public async Task TestCreateAuthorAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Authors", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateAuthorAndReturnOK()
        {
            var author = new Author
            {
                Name = "NameTest",
                LastName = "LastNameTest",
                Born = 1000
            };
            var serialized = JsonConvert.SerializeObject(author);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Authors", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateAuthorAndVerify()
        {
            var author = new Author
            {
                Name = "NameTest",
                LastName = "LastNameTest",
                Born = 1000
            };
            var serialized = JsonConvert.SerializeObject(author);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Authors", queryString);

            var authorCreated = await this.GetConcreteAuthorByName("NameTest");
            // Assert
            Assert.Equal(author.Name, authorCreated.Name);
            Assert.Equal(author.LastName, authorCreated.LastName);
            Assert.Equal(author.Born, authorCreated.Born);
        }


        [Fact]
        public async Task TestUpdateNullAuthorAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Authors/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task TestUpdateAuthorNullIdAndReturnBadRequest()
        {
            var author = new Author
            {
                Name = "NameTest",
                LastName = "LastNameTest",
                Born = 1000
            };
            var serialized = JsonConvert.SerializeObject(author);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Authors/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestUpdateAuthorAndReturnAccepted()
        {
            var author = new Author
            {
                Name = "NameTest",
                LastName = "LastNameTest",
                Born = 1000
            };
            var serialized = JsonConvert.SerializeObject(author);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var authorToUpdate = await this.GetConcreteAuthorByName("Simon");
            var response = await _client.PutAsync($"/Api/Authors/{authorToUpdate.Id}", queryString);
            var authorUpdated = await this.GetConcreteAuthorByName("NameTest");
            // Assert
            Assert.Equal(author.Name, authorUpdated.Name);
            Assert.Equal(author.LastName, authorUpdated.LastName);
            Assert.Equal(author.Born, authorUpdated.Born);
        }


        [Fact]
        public async Task TestUpdateAuthorAndVerify()
        {
            var author = new Author
            {
                Name = "NameTest",
                LastName = "LastNameTest",
                Born = 1000
            };
            var serialized = JsonConvert.SerializeObject(author);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var authorToUpdate = await this.GetConcreteAuthorByName("Simon");
            var response = await _client.PutAsync($"/Api/Authors/{authorToUpdate.Id}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteAuthorAndReturnBadRequest()
        {
            var response = await _client.DeleteAsync($"/Api/Authors/{Guid.Empty}");
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteAuthorAndReturnAccepted()
        {
            var authorSimon = await this.GetConcreteAuthorByName("Simon");
            var response = await _client.DeleteAsync($"/Api/Authors/{authorSimon.Id}");
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteAuthorAndVerify()
        {
            var authorSimon = await this.GetConcreteAuthorByName("Simon");
            var response = await _client.DeleteAsync($"/Api/Authors/{authorSimon.Id}");
            var authorDeleted = await this.GetConcreteAuthorByName("Simon");

            // Assert
            Assert.Null(authorDeleted);
        }


        private async Task<Author> GetConcreteAuthorByName(string name)
        {
            var response = await _client.GetAsync("/Api/Authors");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<List<Author>>(responseString);

            var author = authors.FirstOrDefault(a => a.Name == name);

            return author;
        }

    }
}
