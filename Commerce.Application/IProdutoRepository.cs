using Commerce.Domain;
using Commerce.Application.DTOs;
using System.Collections.Generic;

namespace Commerce.Application;

public interface IProdutoRepository
{
    Task<ListaPaginada<ProdutoDTO>> GetAllProdutosAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true);

    Task<Produto?> GetProdutoByIdAsync(long id);

    Task<Produto> AtualizaProdutoAsync(Produto produto);

    Task<Produto> CriaProdutoAsync(Produto produto);

    Task<List<Produto>> GetProdutosByNomeAsync(string nome);

    Task DeletaProdutoAsync(Produto produto);
}
