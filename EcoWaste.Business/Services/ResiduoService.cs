using Microsoft.EntityFrameworkCore;
using EcoWaste.Core.Entities;
using EcoWaste.DataAccess;
using EcoWaste.Core.DTOs;
using EcoWaste.Core.Extensions;

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
    public async Task<List<Residuo>> ObterTodosAsync(PaginacaoDTO paginacao)
    {
        return await _context.Residuos
            .Skip((paginacao.Pagina - 1) * paginacao.TamanhoPagina)
            .Take(paginacao.TamanhoPagina)
            .ToListAsync();
    }
        public async Task<List<Coleta>> ListarAsync(PaginacaoDTO paginacao)
    {
        return await _context.Coletas
            .OrderBy(c => c.Id) // sempre bom ter uma ordenação
            .Paginar(paginacao)
            .ToListAsync();
    }
}
