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

        public async Task<Produto> AtualizaProdutoAsync(Produto produto)
        {
            return await _produtoRepository.AtualizaProdutoAsync(produto);
        }

        public async Task<Produto> CriaProdutoAsync(Produto produto)
        {
            if (produto.Valor < 0)
            {
                throw new ArgumentException("Product value cannot be negative.");
            }
            return await _produtoRepository.CriaProdutoAsync(produto);
        }

        public async Task DeletaProdutoAsync(Produto produto)
        {
            await _produtoRepository.DeletaProdutoAsync(produto);
        }

        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllProdutosAsync();
        }

        public async Task<Produto?> GetProdutoByIdAsync(int id)
        {
            return await _produtoRepository.GetProdutoByIdAsync(id);
        }

        public async Task<List<Produto>> GetProdutoByNomeAsync(string nome)
        {
            return await _produtoRepository.GetProdutosByNomeAsync(nome);
        }

        /*public async Task<List<Produto>> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente)
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

            return await query.ToListAsync();
        }
        */
    }
}
