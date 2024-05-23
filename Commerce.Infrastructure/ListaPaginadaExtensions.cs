using System.Linq.Expressions;
using Commerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Data;

public static class ListaPaginadaExtensions
{
    public static async Task<ListaPaginada<TFunc>> PaginaFunc<TEntity, TFunc>(
        this IOrderedQueryable<TEntity> source,
        ConfiguracaoPaginacao configuracao,
        Expression<Func<TEntity, TFunc>> func
    )
    {
        var total = await source.CountAsync();

        if (configuracao.TamanhoPagina == -1)
        {
            var todos = await source.Select(func).ToListAsync();

            return new ListaPaginada<TFunc>(
                todos,
                total,
                configuracao.Pagina,
                configuracao.TamanhoPagina
            );
        }

        var result = await source
            .Skip((configuracao.Pagina - 1) * configuracao.TamanhoPagina)
            .Take(configuracao.TamanhoPagina)
            .Select(func)
            .ToListAsync();

        return new ListaPaginada<TFunc>(
            result,
            total,
            configuracao.Pagina,
            configuracao.TamanhoPagina
        );
    }
}
