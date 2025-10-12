using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EcoWaste.Tests
{
    public class PontoColetaControllerTests : IClassFixture<CustomWebApplicationFactory<EcoWaste.Api.Program>>
    {
        private readonly HttpClient _client;

        public PontoColetaControllerTests(CustomWebApplicationFactory<EcoWaste.Api.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllPontosColeta_ReturnsHttp200()
        {
            var response = await _client.GetAsync("/api/PontoColeta");
            response.EnsureSuccessStatusCode(); // Assert HTTP 200
        }
    }
}