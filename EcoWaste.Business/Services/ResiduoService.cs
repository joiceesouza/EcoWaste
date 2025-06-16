using Microsoft.EntityFrameworkCore;
using EcoWaste.Core.Entities;
using EcoWaste.DataAccess;
using EcoWaste.Core.DTOs;

public class ResiduoService : IResiduoService
{
    private readonly EcoTrackDbContext _context;

    public ResiduoService(EcoTrackDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Residuo>> ListarTodosAsync(int page, int pageSize)
    {
        return await _context.Residuos
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Residuo?> ObterPorIdAsync(int id)
    {
        return await _context.Residuos.FindAsync(id);
    }

    public async Task<Residuo> CriarAsync(Residuo residuo)
    {
        _context.Residuos.Add(residuo);
        await _context.SaveChangesAsync();
        return residuo;
    }
}
