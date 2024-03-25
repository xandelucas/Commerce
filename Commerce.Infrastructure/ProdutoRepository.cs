using Commerce.Application;
using Commerce.Domain;
using Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Commerce.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CommerceDBContext _dbContext;

        public ProdutoRepository(CommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Remover o IQueryable()
        public async Task<List<Produto>> GetAllProdutosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            int offset = (pageNumber - 1) * pageSize;
            switch (nomeCampo.ToLower())
            {
                case "id":
                    return isAcendente ? await _dbContext.Produto.OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() : 
                        await _dbContext.Produto.OrderByDescending(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                case "nome":
                    return isAcendente ? await _dbContext.Produto.OrderBy(x => x.Nome).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() :
                        await _dbContext.Produto.OrderByDescending(x => x.Nome).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                case "valor":
                    return isAcendente ? await _dbContext.Produto.OrderBy(x => x.Valor).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() : 
                        await _dbContext.Produto.OrderByDescending(x => x.Valor).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();   
                case "estoque":
                    return isAcendente ? await _dbContext.Produto.OrderBy(x => x.Estoque).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() : 
                        await _dbContext.Produto.OrderByDescending(x => x.Estoque).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                default:
                    throw new ArgumentException("Campo para ordenação inválido");
            }
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
    }
}
