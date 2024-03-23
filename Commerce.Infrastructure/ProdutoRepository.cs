using Commerce.Application;
using Commerce.Domain;
using Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Commerce.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CommerceDBContext _dbContext;

        public ProdutoRepository(CommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Produto> GetAllProdutos()
        {
            return _dbContext.Produto.OrderBy(x => x.Id).ToList();
        }

        public IQueryable<Produto> GetAll()
        {
            return _dbContext.Produto.AsQueryable();
        }

        public Produto GetProdutoById(int id)
        {
            return _dbContext.Produto.Find(id);
        }

        public Produto AtualizaProduto(Produto produto)
        {
            _dbContext.Entry(produto).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return produto;
        }

        public Produto CriaProduto(Produto produto)
        {
            _dbContext.Produto.Add(produto);
            _dbContext.SaveChanges();
            return produto;
        }

        public List<Produto> GetProdutoByNome(string nome)
        {
            return _dbContext.Produto.Where(x => x.Nome.Contains(nome)).ToList();
        }

        public void DeletaProduto(int id)
        {
            var produto = _dbContext.Produto.Find(id);
            if (produto != null)
            {
                _dbContext.Produto.Remove(produto);
                _dbContext.SaveChanges();
            }
        }
    }
}
