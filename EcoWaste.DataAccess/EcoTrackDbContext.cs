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

        public DbSet<Coleta> Coletas { get; set; }
        public DbSet<PontoColeta> PontosColeta { get; set; }
        public DbSet<Residuo> Residuos { get; set; }
        public DbSet<PontoColetaResiduo> PontoColetaResiduos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coleta>(entity =>
            {
                entity.ToTable("COLETA");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO").IsRequired();
                entity.Property(e => e.ResiduoId).HasColumnName("RESIDUO_ID");
                entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(e => e.QuantidadeKg).HasColumnName("QUANTIDADE_KG");
                entity.Property(e => e.DataHora).HasColumnName("DATA_HORA");

                entity.HasOne(e => e.Residuo)
                    .WithMany(r => r.Coletas)
                    .HasForeignKey(e => e.ResiduoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Residuo>(entity =>
            {
                entity.ToTable("RESIDUO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nome).HasColumnName("NOME").IsRequired();
                entity.Property(e => e.Tipo).HasColumnName("TIPO").IsRequired();
            });

            modelBuilder.Entity<PontoColeta>(entity =>
            {
                entity.ToTable("PONTO_COLETA");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nome).HasColumnName("NOME").IsRequired();
                entity.Property(e => e.Endereco).HasColumnName("ENDERECO").IsRequired();
                entity.Property(e => e.Cidade).HasColumnName("CIDADE").IsRequired();
            });

            modelBuilder.Entity<PontoColetaResiduo>(entity =>
            {
                entity.ToTable("PONTO_COLETA_RESIDUO");

                entity.HasKey(e => new { e.PontoColetaId, e.ResiduoId });

                entity.Property(e => e.PontoColetaId).HasColumnName("PONTO_COLETA_ID");
                entity.Property(e => e.ResiduoId).HasColumnName("RESIDUO_ID");

                entity.HasOne(e => e.PontoColeta)
                      .WithMany(p => p.PontoColetaResiduos)
                      .HasForeignKey(e => e.PontoColetaId)
                      .HasConstraintName("FK_PONTOCOLETA_RESIDUO_PONTOCOLETA")
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Residuo)
                      .WithMany(r => r.PontoColetaResiduos)
                      .HasForeignKey(e => e.ResiduoId)
                      .HasConstraintName("FK_PONTOCOLETA_RESIDUO_RESIDUO")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Padroniza todas as tabelas e colunas como UPPERCASE
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToUpper());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnBaseName().ToUpper());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToUpper());
                }

                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.SetConstraintName(fk.GetConstraintName().ToUpper());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToUpper());
                }
            }
        }
    }
}
