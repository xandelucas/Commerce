using Commerce.Domain;

namespace Commerce.Infrastructure.Interfaces;

public interface IRepository<T> where T : class
{
    Task<ListaPaginada<T>> GetAllAsync();
    Task<T?> GetByIdAsync(long id);
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(long id);
}
