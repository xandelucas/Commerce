using Commerce.Application.DTOs;
using Commerce.Domain;

namespace Commerce.Application;

public interface ICategoriaRepository 
{
    Task<ListaPaginada<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(long id);
    Task InsertAsync(Categoria entity);
    Task UpdateAsync(Categoria entity);
    Task DeleteAsync(long id);
    Task<ListaPaginada<CategoriaDTO>> GetAllCategoriasAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente);
}
