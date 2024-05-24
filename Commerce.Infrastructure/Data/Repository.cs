using Commerce.Domain;
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
    protected readonly CommerceDBContext Context;
    protected DbSet<T> DbSet;

    public Repository(CommerceDBContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<ListaPaginada<T>> GetAllAsync()
    {
        var items = await DbSet.ToListAsync();

        return new ListaPaginada<T>(items, items.Count, 1, items.Count);
    }

    public async Task<T?> GetByIdAsync(long id)
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

    public async Task DeleteAsync(long id)
    {
        T? entityToDelete = await DbSet.FindAsync(id);
        if (entityToDelete != null)
        {
            DbSet.Remove(entityToDelete);
            await Context.SaveChangesAsync();
        }
    }
}
