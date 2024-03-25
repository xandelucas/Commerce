using Commerce.Domain;
using System.Collections.Generic;

namespace Commerce.Application
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllProdutosAsync();

        IQueryable<Produto> GetAll();

        Task<Produto?> GetProdutoByIdAsync(int id);

        Task<Produto> AtualizaProdutoAsync(Produto produto);

        Task<Produto> CriaProdutoAsync(Produto produto);

        Task<List<Produto>> GetProdutosByNomeAsync(string nome);

        Task DeletaProdutoAsync(Produto produto);
    }
}
