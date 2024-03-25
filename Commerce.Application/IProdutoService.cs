using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAllProdutosAsync();

        Task<Produto?> GetProdutoByIdAsync(int id);

        Task<Produto?> AtualizaProdutoAsync(Produto produto);

        Task<Produto> CriaProdutoAsync(Produto produto);

        //Task<List<Produto>> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente);

        Task<List<Produto>> GetProdutoByNomeAsync(string nome);

        Task DeletaProdutoAsync(Produto produto);
    }
}
