using AutoMapper;
using Commerce.Application;
using Commerce.Application.DTOs;
using Commerce.Domain;
using Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Commerce.Infrastructure.Repositorys;

public class ProdutoRepository : IProdutoRepository
{
    private readonly CommerceDBContext _dbContext;
    private readonly IMapper _mapper;

    public ProdutoRepository(CommerceDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ListaPaginada<ProdutoDTO>> GetAllProdutosAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true)
    {
        return nomeCampo.ToLowerInvariant() switch
        {
            "id"
                => isAcendente
                    ? await _dbContext
                        .Produto.OrderBy(x => x.Id)
                        .PaginaFunc(configuracao, ToDTO())
                    : await _dbContext
                        .Produto.OrderByDescending(x => x.Id)
                        .PaginaFunc(configuracao, ToDTO()),
            "nome"
                => isAcendente
                    ? await _dbContext
                        .Produto.OrderBy(x => x.Nome)
                        .PaginaFunc(configuracao, ToDTO())
                    : await _dbContext
                        .Produto.OrderByDescending(x => x.Nome)
                        .PaginaFunc(configuracao, ToDTO()),
            _ => throw new ArgumentException("Campo para ordenação inválido"),
        };
    }


    public async Task<Produto?> GetProdutoByIdAsync(long id)
    {
        return await _dbContext.Produto.FindAsync(id);
    }

    public async Task<Produto> AtualizaProdutoAsync(Produto produto)
    {
        _dbContext.Entry(produto).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> CriaProdutoAsync(Produto produto)
    {
        _dbContext.Produto.Add(produto);
        await _dbContext.SaveChangesAsync();
        return produto;
    }

    public async Task<List<Produto>> GetProdutosByNomeAsync(string nome)
    {
        return await _dbContext.Produto.Where(x => x.Nome.Contains(nome)).ToListAsync();
    }

    public async Task DeletaProdutoAsync(Produto produto)
    {
        _dbContext.Produto.Remove(produto);
        await _dbContext.SaveChangesAsync();
    }

    private Expression<Func<Produto, ProdutoDTO>> ToDTO()
    {
        return t => _mapper.Map<ProdutoDTO>(t);
    }
}
