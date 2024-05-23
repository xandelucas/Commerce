using Commerce.Application.DTOs;
using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.IServices;

public interface IProdutoService
{
    Task<ListaPaginada<ProdutoDTO>> GetAllProdutosAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true);

    Task<Produto?> GetProdutoByIdAsync(long id);

    Task<Produto> AtualizaProdutoAsync(ProdutoDTO produtoDTO);

    Task<Produto> CriaProdutoAsync(ProdutoDTO produtoDTO);

    Task<List<Produto>> GetProdutoByNomeAsync(string nome);

    Task DeletaProdutoAsync(Produto produto);
}
