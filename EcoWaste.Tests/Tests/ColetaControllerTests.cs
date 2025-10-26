using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using EcoWaste.Api; // para Program parcial

namespace EcoWaste.Tests
{
    public class ColetaControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ColetaControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllColetas_ReturnsHttp200()
        {
            var response = await _client.GetAsync("/api/Coleta");
            response.EnsureSuccessStatusCode();
        }
    }
}