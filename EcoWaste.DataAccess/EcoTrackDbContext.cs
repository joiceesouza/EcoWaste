using Microsoft.EntityFrameworkCore;
using EcoWaste.Core.Entities;

namespace EcoWaste.DataAccess
{
    public class EcoTrackDbContext : DbContext
    {
        public EcoTrackDbContext(DbContextOptions<EcoTrackDbContext> options)
            : base(options)
        {
        }

        public DbSet<Residuo> Residuos { get; set; }
        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<PontoColeta> PontosColeta { get; set; }
    }
}