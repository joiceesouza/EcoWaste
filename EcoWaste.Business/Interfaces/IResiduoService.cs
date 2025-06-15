public interface IResiduoService
{
    Task<IEnumerable<Residuo>> ListarTodosAsync(int page, int pageSize);
    Task<Residuo?> ObterPorIdAsync(int id);
    Task<Residuo> CriarAsync(Residuo residuo);
}
