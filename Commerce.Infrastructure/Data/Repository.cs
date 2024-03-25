using Commerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entityToDelete = DbSet.Find(id);
            if (entityToDelete != null)
            {
                DbSet.Remove(entityToDelete);
            }
        }
    }
}
