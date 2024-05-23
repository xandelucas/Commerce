using Commerce.Domain;
using System.Collections.Generic;

namespace Commerce.Application;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllProdutosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10);

    Task<Produto?> GetProdutoByIdAsync(long id);

    Task<Produto> AtualizaProdutoAsync(Produto produto);

    Task<Produto> CriaProdutoAsync(Produto produto);

    Task<List<Produto>> GetProdutosByNomeAsync(string nome);

    Task DeletaProdutoAsync(Produto produto);
}
