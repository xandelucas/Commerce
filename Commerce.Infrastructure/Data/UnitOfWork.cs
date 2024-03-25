using Commerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace Commerce.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommerceDBContext _dbContext;
        private bool _disposed;
        private IDbContextTransaction? _trasaction;

        public UnitOfWork(CommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _trasaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            _trasaction?.Commit();
        }

        public void Rollback()
        {
            _trasaction?.Rollback();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
