using EcoWaste.Core.DTOs;
using EcoWaste.Core.Entities;

public interface IResiduoService
{
    Task<IEnumerable<Residuo>> ListarTodosAsync(int page, int pageSize);
    Task<Residuo?> ObterPorIdAsync(int id);
    Task<Residuo> CriarAsync(Residuo residuo);
}