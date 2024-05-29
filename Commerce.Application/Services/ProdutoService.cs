using AutoMapper;
using Commerce.Application.DTOs;
using Commerce.Application.IServices;
using Commerce.Domain;
using FluentValidation;


namespace Commerce.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;
    private static ProdutoDTOValidator _produtoDTOValidator = new();

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, ICategoriaService categoriaService)
    {
        this._produtoRepository = produtoRepository;
        this._mapper = mapper;
        this._categoriaService = categoriaService;
    }
        
    public async Task<Produto> AtualizaProdutoAsync(ProdutoDTO produtoDTO)
    {
        _produtoDTOValidator.ValidateAndThrow(produtoDTO);
        var categoria = await _categoriaService.GetCategoriaByIdAsync(produtoDTO.CategoriaId);
        if (categoria == null)
        {
            throw new ArgumentException("Categoria não encontrada.");
        }
        return await _produtoRepository.CriaProdutoAsync(_mapper.Map<Produto>(produtoDTO));
    }

    public async Task<Produto> CriaProdutoAsync(ProdutoDTO produtoDTO)
    {
        _produtoDTOValidator.ValidateAndThrow(produtoDTO);
        var categoria = await _categoriaService.GetCategoriaByIdAsync(produtoDTO.CategoriaId);
        if (categoria == null)
        {
            throw new ArgumentException("Categoria não encontrada.");
        }
        return await _produtoRepository.AtualizaProdutoAsync(_mapper.Map<Produto>(produtoDTO));
    }

    public async Task DeletaProdutoAsync(Produto produto)
    {
        await _produtoRepository.DeletaProdutoAsync(produto);
    }

    public async Task<ListaPaginada<ProdutoDTO>> GetAllProdutosAsync(string nomeCampo,
            ConfiguracaoPaginacao configuracao,
            bool isAcendente = true)
    {
        return await _produtoRepository.GetAllProdutosAsync(nomeCampo, configuracao, isAcendente);
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
