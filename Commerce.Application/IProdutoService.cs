using Commerce.Application.DTOs;
using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application;

public interface IProdutoService
{
    Task<List<Produto>> GetAllProdutosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10);

    Task<Produto?> GetProdutoByIdAsync(long id);

    Task<Produto> AtualizaProdutoAsync(ProdutoDTO produtoDTO);

    Task<Produto> CriaProdutoAsync(ProdutoDTO produtoDTO);

    Task<List<Produto>> GetProdutoByNomeAsync(string nome);

    Task DeletaProdutoAsync(Produto produto);
}
