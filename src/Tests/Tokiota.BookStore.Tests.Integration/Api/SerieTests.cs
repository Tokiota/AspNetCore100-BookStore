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
    public class SerieTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public SerieTests()
        {
            _server = new TestServer(new WebHostBuilder()
                       .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetSeries()
        {
            // Act
            var response = await _client.GetAsync("/Api/Series");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var series = JsonConvert.DeserializeObject<List<Serie>>(responseString);
            // Assert
            Assert.NotNull(series);
            Assert.True(series.Any());
        }

        [Fact]
        public async Task TestGetSeriesAndGetSerieEagles()
        {
            var serie = await this.GetConcreteSerieByName("Eagles of the Empire");
            // Assert
            Assert.NotNull(serie);
            Assert.Equal("Eagles of the Empire", serie.Name);
        }

        [Fact]
        public async Task TestCreateSerieAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Series", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateSerieAndReturnCreated()
        {
            var serie = new Serie
            {
                Name = "NameTest",
            };
            var serialized = JsonConvert.SerializeObject(serie);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Series", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateSerieAndVerify()
        {
            var serie = new Serie
            {
                Name = "NameTest",
            };
            var serialized = JsonConvert.SerializeObject(serie);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/Api/Series", queryString);

            var serieCreated = await this.GetConcreteSerieByName("NameTest");
            // Assert
            Assert.Equal(serie.Name, serieCreated.Name);
        }


        [Fact]
        public async Task TestUpdateNullSerieAndReturnBadRequest()
        {
            StringContent queryString = new StringContent("blabla=bla", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Series/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task TestUpdateSerieNullIdAndReturnBadRequest()
        {
            var serie = new Serie
            {
                Name = "NameTest",
            };
            var serialized = JsonConvert.SerializeObject(serie);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"/Api/Series/{Guid.Empty}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestUpdateSerieAndReturnAccepted()
        {
            var serie = new Serie
            {
                Name = "NameTest",
            };
            var serialized = JsonConvert.SerializeObject(serie);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var serieToUpdate = await this.GetConcreteSerieByName("Eagles of the Empire");
            var response = await _client.PutAsync($"/Api/Series/{serieToUpdate.Id}", queryString);
            var serieUpdated = await this.GetConcreteSerieByName("NameTest");
            // Assert
            Assert.Equal(serie.Name, serieUpdated.Name);
        }


        [Fact]
        public async Task TestUpdateSerieAndVerify()
        {
            var serie = new Serie
            {
                Name = "NameTest",
            };
            var serialized = JsonConvert.SerializeObject(serie);
            StringContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var serieToUpdate = await this.GetConcreteSerieByName("Eagles of the Empire");
            var response = await _client.PutAsync($"/Api/Series/{serieToUpdate.Id}", queryString);
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteSerieAndReturnBadRequest()
        {
            var response = await _client.DeleteAsync($"/Api/Series/{Guid.Empty}");
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteSerieAndReturnAccepted()
        {
            var serieSimon = await this.GetConcreteSerieByName("Eagles of the Empire");
            var response = await _client.DeleteAsync($"/Api/Series/{serieSimon.Id}");
            // Assert
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact]
        public async Task TestDeleteSerieAndVerify()
        {
            var serieSimon = await this.GetConcreteSerieByName("Eagles of the Empire");
            var response = await _client.DeleteAsync($"/Api/Series/{serieSimon.Id}");
            var serieDeleted = await this.GetConcreteSerieByName("Eagles of the Empire");

            // Assert
            Assert.Null(serieDeleted);
        }


        private async Task<Serie> GetConcreteSerieByName(string name)
        {
            var response = await _client.GetAsync("/Api/Series");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var series = JsonConvert.DeserializeObject<List<Serie>>(responseString);

            var serie = series.FirstOrDefault(a => a.Name == name);

            return serie;
        }

    }
}
