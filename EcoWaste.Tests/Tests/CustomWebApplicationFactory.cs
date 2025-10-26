using Microsoft.AspNetCore.Mvc.Testing;

namespace EcoWaste.Tests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
    }
}