public interface IColetaService
{
    Task<Coleta> RegistrarAsync(CreateColetaDto coletaDto, int usuarioId);
    Task<IEnumerable<ColetaResponseDto>> ListarAsync(int page, int pageSize);
    Task<IEnumerable<ColetaResponseDto>> ObterPorTipoResiduoAsync(string tipo);
}
