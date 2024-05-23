using Commerce.Infrastructure.Interfaces;
using Commerce.Domain;
using AutoMapper;
using Commerce.Infrastructure.Data;
using Commerce.Application.DTOs;
using System.Linq.Expressions;
using Commerce.Application;

namespace Commerce.Infrastructure.Repositorys;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly CommerceDBContext _dbContext;
    private readonly IMapper _mapper;
    private readonly Repository<Categoria> _categoriaRepository;
    public CategoriaRepository(CommerceDBContext dbContext, IMapper mapper, Repository<Categoria> categoriaRepository)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _categoriaRepository = categoriaRepository;
    }
    public async Task DeleteAsync(Categoria categoria)
    {
        _dbContext.Categorias.Remove(categoria);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        await _categoriaRepository.DeleteAsync(id);
    }

    public async Task<ListaPaginada<Categoria>> GetAllAsync()
    {
        return await _categoriaRepository.GetAllAsync();
    }

    public async Task<ListaPaginada<CategoriaDTO>> GetAllCategoriasAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true)
    {
        return nomeCampo.ToLowerInvariant() switch
        {
            "nome" => isAcendente
               ? await _dbContext
                   .Categorias.OrderBy(x => x.Nome)
                   .PaginaFunc(configuracao, ToDTO())
                : await _dbContext
                   .Categorias.OrderByDescending(x => x.Nome)
                   .PaginaFunc(configuracao, ToDTO()),
            _ => throw new ArgumentException("Campo para ordenação inválido"),
        };
    }

    public async Task<Categoria?> GetByIdAsync(long id)
    {
        return await _categoriaRepository.GetByIdAsync(id);
    }

    public async Task InsertAsync(Categoria entity)
    {
        await _categoriaRepository.InsertAsync(entity);
    }

    public async Task UpdateAsync(Categoria entity)
    {
        await _categoriaRepository.UpdateAsync(entity);
    }

    private Expression<Func<Categoria, CategoriaDTO>> ToDTO()
    {
        return t => _mapper.Map<CategoriaDTO>(t);
    }
}
