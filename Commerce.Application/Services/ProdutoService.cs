using AutoMapper;
using Commerce.Application.DTOs;
using Commerce.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private static ProdutoDTOValidator _produtoDTOValidator = new();

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
    {
        this._produtoRepository = produtoRepository;
        this._mapper = mapper;
    }

    public async Task<Produto> AtualizaProdutoAsync(ProdutoDTO produtoDTO)
    {
        _produtoDTOValidator.ValidateAndThrow(produtoDTO);
        return await _produtoRepository.AtualizaProdutoAsync(_mapper.Map<Produto>(produtoDTO));
    }

    public async Task<Produto> CriaProdutoAsync(ProdutoDTO produtoDTO)
    {
        _produtoDTOValidator.ValidateAndThrow(produtoDTO);
        return await _produtoRepository.CriaProdutoAsync(_mapper.Map<Produto>(produtoDTO));
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

    public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoDTOValidator()
        {
            RuleFor(x => x.Estoque).GreaterThan(0).WithMessage("O estoque do produto deve ser maior que 0!");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("O valor do produto deve ser maior que 0!");
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.CategoriaId).NotNull();
        }
    }
}
