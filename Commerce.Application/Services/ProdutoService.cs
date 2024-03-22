using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public Produto AtualizaProduto(Produto produto)
        {
            return _produtoRepository.AtualizaProduto(produto);
        }

        public Produto CriaProduto(Produto produto)
        {
            if (produto.Valor < 0)
            {
                throw new ArgumentException("Product value cannot be negative.");
            }
            return _produtoRepository.CriaProduto(produto);
        }

        public void DeletaProduto(int id)
        {
            _produtoRepository.DeletaProduto(id);
        }

        public List<Produto> GetAllProdutos()
        {
            return _produtoRepository.GetAllProdutos();
        }

        public Produto GetProdutoById(int id)
        {
            return _produtoRepository.GetProdutoById(id);
        }

        public List<Produto> GetProdutoByNome(string nome)
        {
            return _produtoRepository.GetProdutoByNome(nome);
        }

        public List<Produto> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente)
        {
            var query = _produtoRepository.GetAll();

            switch (nomeCampo.ToLower())
            {
                case "nome":
                    query = isAscendente ? query.OrderBy(p => p.Nome) : query.OrderByDescending(p => p.Nome);
                    break;
                case "valor":
                    query = isAscendente ? query.OrderBy(p => p.Valor) : query.OrderByDescending(p => p.Valor);
                    break;
                case "estoque":
                    query = isAscendente ? query.OrderBy(p => p.Estoque) : query.OrderByDescending(p => p.Estoque);
                    break;
                default:
                    throw new ArgumentException("Campo para ordenação inválido");
            }

            return query.ToList();
        }
    }
}
