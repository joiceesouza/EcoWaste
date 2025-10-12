using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EcoWaste.Tests
{
    public class ColetaControllerTests : IClassFixture<CustomWebApplicationFactory<EcoWaste.Api.Program>>
    {
        private readonly HttpClient _client;

        public ColetaControllerTests(CustomWebApplicationFactory<EcoWaste.Api.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllColetas_ReturnsHttp200()
        {
            var response = await _client.GetAsync("/api/Coleta");
            response.EnsureSuccessStatusCode(); // Assert HTTP 200
        }
    }
}