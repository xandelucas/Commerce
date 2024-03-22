using Commerce.Domain;
using System.Collections.Generic;

namespace Commerce.Application
{
    public interface IProdutoRepository
    {
        List<Produto> GetAllProdutos();

        IQueryable<Produto> GetAll();

        Produto GetProdutoById(int id);

        Produto AtualizaProduto(Produto produto);

        Produto CriaProduto(Produto produto);

        List<Produto> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente);

        List<Produto> GetProdutoByNome(string nome);

        void DeletaProduto(int id);
    }
}
