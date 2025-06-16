using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EcoWaste.DataAccess
{
    public class EcoTrackDbContextFactory : IDesignTimeDbContextFactory<EcoTrackDbContext>
    {
        public EcoTrackDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Certifique-se que a execução esteja na pasta EcoWaste.DataAccess
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EcoTrackDbContext>();

            var connectionString = configuration.GetConnectionString("EcoTrackDatabase");

            optionsBuilder.UseOracle(connectionString);

            return new EcoTrackDbContext(optionsBuilder.Options);
        }
    }
}