using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Web;
using Xunit;

namespace Tokiota.BookStore.Tests.Integration.Api
{
    public class AuthorTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AuthorTests()
        {
            _server = new TestServer(new WebHostBuilder()
                       .UseStartup<Startup>());
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
            // Act
            var response = await _client.GetAsync("/Api/Authors");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<List<Author>>(responseString);

            var id = authors.FirstOrDefault(a => a.Name == "Simon").Id;
            var responseConcreteAuthor = await _client.GetAsync($"/Api/Authors/{id}");
            responseConcreteAuthor.EnsureSuccessStatusCode();
            var responseStringConcreteAuthor = await response.Content.ReadAsStringAsync();
            var author = JsonConvert.DeserializeObject<List<Author>>(responseStringConcreteAuthor);

            // Assert
            Assert.NotNull(author);
        }

    }
}
