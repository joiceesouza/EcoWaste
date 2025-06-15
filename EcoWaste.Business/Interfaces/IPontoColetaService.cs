public interface IPontoColetaService
{
    Task<IEnumerable<PontoColetaDto>> ListarPorCidadeAsync(string cidade);
    Task<PontoColeta> CriarAsync(PontoColeta ponto);
}
