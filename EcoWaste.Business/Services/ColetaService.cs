using EcoWaste.Core.Entities;
using EcoWaste.Core.DTOs;
using EcoWaste.DataAccess;

public class ColetaService : IColetaService
{
    private readonly EcoTrackDbContext _context;

    public ColetaService(EcoTrackDbContext context)
    {
        _context = context;
    }

    public async Task<Coleta> RegistrarAsync(CreateColetaDto dto, int usuarioId)
    {
        var coleta = new Coleta
        {
            ResiduoId = dto.ResiduoId,
            UsuarioId = usuarioId,
            QuantidadeKg = dto.QuantidadeKg,
            DataHora = DateTime.UtcNow
        };

        _context.Coletas.Add(coleta);
        await _context.SaveChangesAsync();
        return coleta;
    }

    public async Task<IEnumerable<ColetaResponseDto>> ListarAsync(int page, int pageSize)
    {
        return await _context.Coletas
            .Include(c => c.Residuo)
            .Select(c => new ColetaResponseDto
            {
                Id = c.Id,
                ResiduoTipo = c.Residuo!.Tipo,
                QuantidadeKg = c.QuantidadeKg,
                DataHora = c.DataHora
            })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<ColetaResponseDto>> ObterPorTipoResiduoAsync(string tipo)
    {
        return await _context.Coletas
            .Include(c => c.Residuo)
            .Where(c => c.Residuo!.Tipo == tipo)
            .Select(c => new ColetaResponseDto
            {
                Id = c.Id,
                ResiduoTipo = c.Residuo!.Tipo,
                QuantidadeKg = c.QuantidadeKg,
                DataHora = c.DataHora
            }).ToListAsync();
    }
}