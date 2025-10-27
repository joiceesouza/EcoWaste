using EcoWaste.Core.Entities;
using EcoWaste.Core.DTOs;
using EcoWaste.DataAccess;
using Microsoft.EntityFrameworkCore;
using EcoWaste.Core.Extensions;

namespace EcoWaste.Business.Services
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly EcoTrackDbContext _context;

        public PontoColetaService(EcoTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoColetaDto>> ListarPorCidadeAsync(string cidade)
        {
            return await _context.PontoColetas
                .Where(p => p.Cidade.ToLower() == cidade.ToLower())
                .Select(p => new PontoColetaDto
                {
                    Nome = p.Nome,
                    Endereco = p.Endereco,
                    Cidade = p.Cidade,
                    TiposResiduosAceitos = p.TiposResiduosAceitos
                    .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                }).ToListAsync();
        }

        public async Task<PontoColeta> CriarAsync(PontoColeta ponto)
        {
            _context.PontoColetas.Add(ponto);
            await _context.SaveChangesAsync();
            return ponto;
        }

        public async Task<List<PontoColeta>> ListarAsync(PaginacaoDTO paginacao)
        {
            return await _context.PontoColetas
                .Skip((paginacao.Pagina - 1) * paginacao.TamanhoPagina)
                .Take(paginacao.TamanhoPagina)
                .ToListAsync();
        }
    }
        
}