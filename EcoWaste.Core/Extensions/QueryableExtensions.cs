using EcoWaste.Core.DTOs;
using System.Linq;

namespace EcoWaste.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> query, PaginacaoDTO paginacao)
        {
            if (paginacao == null)
                return query;

            return query
                .Skip((paginacao.Pagina - 1) * paginacao.TamanhoPagina)
                .Take(paginacao.TamanhoPagina);
        }
    }
}