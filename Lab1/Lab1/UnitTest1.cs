using Lab1.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Lab1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetValidZipCodeReturns200()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/90210");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task TestGetInvalidZipCodeReturns404()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/00000");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Test]
        public async Task TestGetValidZipCodeReturnsExpectedData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/90210");
            dynamic data = await response.Content.ReadFromJsonAsync<ZipData>();
            Assert.AreEqual("Beverly Hills", data.Places[0].PlaceName);
        }
        [Test]
        public async Task TestGetValidStateAndCityReturnsExpectedData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/ca/los angeles");
            dynamic data = await response.Content.ReadFromJsonAsync<ZipData>();
            Assert.AreEqual("90001", data.Places[0].PostalCode);
        }

        [Test]
        public async Task TestGetInvalidStateAndCityReturns404()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/xx/invalid city");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task TestPostEndpointReturns405()
        {
            var client = new HttpClient();
            var response = await client.PostAsync("https://api.zippopotam.us/us/90210", null);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Test]
        public async Task TestPutEndpointReturns405()
        {
            var client = new HttpClient();
            var response = await client.PutAsync("https://api.zippopotam.us/us/90210", null);
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteEndpointReturns405()
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync("https://api.zippopotam.us/us/90210");
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Test]
        public async Task TestGetEndpointReturnsExpectedContentType()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/us/90210");
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Test]
        public async Task TestGetInvalidCountryReturns404()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.zippopotam.us/xx/90210");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}