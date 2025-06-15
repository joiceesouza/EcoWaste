using EcoWaste.Core.Entities;
using EcoWaste.Core.DTOs;
using EcoWaste.DataAccess;

public class PontoColetaService : IPontoColetaService
{
    private readonly EcoTrackDbContext _context;

    public PontoColetaService(EcoTrackDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PontoColetaDto>> ListarPorCidadeAsync(string cidade)
    {
        return await _context.PontosColeta
            .Where(p => p.Cidade.ToLower() == cidade.ToLower())
            .Select(p => new PontoColetaDto
            {
                Nome = p.Nome,
                Endereco = p.Endereco,
                Cidade = p.Cidade,
                TiposResiduosAceitos = p.TiposResiduosAceitos.Select(r => r.Tipo).ToList()
            }).ToListAsync();
    }

    public async Task<PontoColeta> CriarAsync(PontoColeta ponto)
    {
        _context.PontosColeta.Add(ponto);
        await _context.SaveChangesAsync();
        return ponto;
    }
}