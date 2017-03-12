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
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Web;
using Xunit;

namespace Tokiota.BookStore.Tests.Integration.Api
{
    public class BookTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BookTests()
        {
            _server = new TestServer(new WebHostBuilder()
                       .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetBooks()
        {
            // Act
            var response = await _client.GetAsync("/Api/Books");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<Book>>(responseString);
            // Assert
            Assert.NotNull(books);
            Assert.True(books.Any());
        }

        [Fact]
        public async Task TestGetBooksAndGetBookSimon()
        {
            var book = await this.GetConcreteBookByName("Under the Eagle");
            // Assert
            Assert.NotNull(book);
            Assert.Equal("Under the Eagle", book.Name);
            Assert.Equal("Historical novel", book.Genre);
            Assert.Equal(2000, book.Published);
        }

        [Fact]
        public async Task TestCreateBookAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Books", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateBookAndReturnOK()
        {
            var book = new Book
            {
                Name = "NameTest",
                Genre = "GenreTest",
                Published = 1000
            };
            var serialized = JsonConvert.SerializeObject(book);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Books", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateBookAndVerify()
        {
            var book = new Book
            {
                Name = "NameTest",
                Genre = "GenreTest",
                Published = 1000
            };
            var serialized = JsonConvert.SerializeObject(book);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Books", queryString);

            var bookCreated = await this.GetConcreteBookByName("NameTest");
            // Assert
            Assert.Equal(book.Name, bookCreated.Name);
            Assert.Equal(book.Genre, bookCreated.Genre);
            Assert.Equal(book.Published, bookCreated.Published);
        }


        [Fact]
        public async Task TestUpdateNullBookAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Books/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task TestUpdateBookNullIdAndReturnBadRequest()
        {
            var book = new Book
            {
                Name = "NameTest",
                Genre = "GenreTest",
                Published = 1000
            };
            var serialized = JsonConvert.SerializeObject(book);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Books/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestUpdateBookAndReturnAccepted()
        {
            var book = new Book
            {
                Name = "NameTest",
                Genre = "GenreTest",
                Published = 1000
            };
            var serialized = JsonConvert.SerializeObject(book);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var bookToUpdate = await this.GetConcreteBookByName("Under the Eagle");
            var response = await _client.PutAsync($"/Api/Books/{bookToUpdate.Id}", queryString);
            var bookUpdated = await this.GetConcreteBookByName("NameTest");
            // Assert
            Assert.Equal(book.Name, bookUpdated.Name);
            Assert.Equal(book.Genre, bookUpdated.Genre);
            Assert.Equal(book.Published, bookUpdated.Published);
        }


        [Fact]
        public async Task TestUpdateBookAndVerify()
        {
            var book = new Book
            {
                Name = "NameTest",
                Genre = "GenreTest",
                Published = 1000
            };
            var serialized = JsonConvert.SerializeObject(book);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var bookToUpdate = await this.GetConcreteBookByName("Under the Eagle");
            var response = await _client.PutAsync($"/Api/Books/{bookToUpdate.Id}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteBookAndReturnBadRequest()
        {
            var response = await _client.DeleteAsync($"/Api/Books/{Guid.Empty}");
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteBookAndReturnAccepted()
        {
            var bookSimon = await this.GetConcreteBookByName("Under the Eagle");
            var response = await _client.DeleteAsync($"/Api/Books/{bookSimon.Id}");
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteBookAndVerify()
        {
            var bookSimon = await this.GetConcreteBookByName("Under the Eagle");
            var response = await _client.DeleteAsync($"/Api/Books/{bookSimon.Id}");
            var bookDeleted = await this.GetConcreteBookByName("Under the Eagle");

            // Assert
            Assert.Null(bookDeleted);
        }


        private async Task<Book> GetConcreteBookByName(string name)
        {
            var response = await _client.GetAsync("/Api/Books");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<Book>>(responseString);

            var book = books.FirstOrDefault(a => a.Name.Contains(name));

            return book;
        }

    }





}
