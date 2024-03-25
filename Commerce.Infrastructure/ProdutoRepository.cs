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

        //Todo Tornar todos os métodos ASync
        //ToDo Paginar
        //Adicionar DTO no Service
        //Remover o IQueryable()
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            return await _dbContext.Produto.OrderBy(x => x.Id).ToListAsync();
        }

        public IQueryable<Produto> GetAll()
        {
            return _dbContext.Produto.AsQueryable();
        }

        public async Task<Produto?> GetProdutoByIdAsync(int id)
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
    }
}
