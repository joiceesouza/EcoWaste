using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EcoWaste.Tests
{
    public class ResiduoControllerTests : IClassFixture<CustomWebApplicationFactory<EcoWaste.Api.Program>>
    {
        private readonly HttpClient _client;

        public ResiduoControllerTests(CustomWebApplicationFactory<EcoWaste.Api.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllResiduos_ReturnsHttp200()
        {
            var response = await _client.GetAsync("/api/Residuo");
            response.EnsureSuccessStatusCode(); // Assert HTTP 200
        }
    }
}