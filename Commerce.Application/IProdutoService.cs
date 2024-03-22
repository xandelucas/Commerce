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
        List<Produto> GetAllProdutos();

        Produto GetProdutoById(int id);

        Produto AtualizaProduto(Produto produto);

        Produto CriaProduto(Produto produto);

        List<Produto> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente);

        List<Produto> GetProdutoByNome(string nome);

        void DeletaProduto(int id);
    }
}
