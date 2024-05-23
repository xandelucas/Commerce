using Commerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.Data;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    protected DbSet<T> DbSet;

    public Repository(DbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task InsertAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T? entityToDelete = await DbSet.FindAsync(id);
        if (entityToDelete != null)
        {
            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync();
        }
    }
}
