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

        public static List<Produto> listaProdutos = new List<Produto>(){
            new Produto{Id = 1, Estoque = 10, Valor = 1000, Nome = "Tablet"         },
            new Produto{Id = 2, Estoque = 10, Valor = 1500, Nome = "Notebook"       },
            new Produto{Id = 3, Estoque = 10, Valor = 4000, Nome = "Playstation 5"  },
            new Produto{Id = 4, Estoque = 10, Valor = 2000, Nome = "Nintendo Switch"},
            new Produto{Id = 5, Estoque = 10, Valor = 6000, Nome = "Tablet"}
            };
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
            throw new NotImplementedException();
        }

        public Produto AtualizaProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto CriaProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public List<Produto> GetProdutosOrdenadosPor(string nomeCampo, bool isAscendente)
        {
            throw new NotImplementedException();
        }

        public List<Produto> GetProdutoByNome(string nome)
        {
            return _dbContext.Produto.Where(x => x.Nome.Contains(nome)).ToList();
        }

        public void DeletaProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
