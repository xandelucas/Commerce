using AutoMapper;
using Commerce.Application.DTOs;
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
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        public async Task<Produto> AtualizaProdutoAsync(ProdutoDTO produtoDTO,Produto produto)
        {
            if (produtoDTO.Valor < 0)
            {
                throw new ArgumentException("O valor do produto não pode ser negativo!");
            }

            produto.Nome = produtoDTO.Nome;
            produto.Valor = produtoDTO.Valor;
            produto.Estoque = produtoDTO.Estoque;

             
            return await _produtoRepository.AtualizaProdutoAsync(produto);
        }

        public async Task<Produto> CriaProdutoAsync(ProdutoDTO produtoDTO)
        {
            if (produtoDTO.Valor < 0)
            {
                throw new ArgumentException("O valor do produto não pode ser negativo!");
            }
            var produto = _mapper.Map<Produto>(produtoDTO);
            return await _produtoRepository.CriaProdutoAsync(produto);
        }

        public async Task DeletaProdutoAsync(Produto produto)
        {
            await _produtoRepository.DeletaProdutoAsync(produto);
        }

        public async Task<List<Produto>> GetAllProdutosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            return await _produtoRepository.GetAllProdutosAsync(nomeCampo, isAcendente, pageNumber, pageSize);
        }

        public async Task<Produto?> GetProdutoByIdAsync(long id)
        {
            return await _produtoRepository.GetProdutoByIdAsync(id);
        }

        public async Task<List<Produto>> GetProdutoByNomeAsync(string nome)
        {
            return await _produtoRepository.GetProdutosByNomeAsync(nome);
        }

    }
}
