using EcoWaste.Core.DTOs;
using EcoWaste.Core.Entities;

public interface IPontoColetaService
{
    Task<IEnumerable<PontoColetaDto>> ListarPorCidadeAsync(string cidade);
    Task<PontoColeta> CriarAsync(PontoColeta ponto);
}