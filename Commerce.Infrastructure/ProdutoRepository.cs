using Commerce.Application;
using Commerce.Domain;
using System.Collections.Generic;

namespace Commerce.Infrastructure
{
    public class ProdutoRepository : IProdutoRepository
    {
        public static List<Produto> listaProdutos = new List<Produto>(){
            new Produto{Id = 1, Estoque = 10, Valor = 1000, Nome = "Tablet"         },
            new Produto{Id = 2, Estoque = 10, Valor = 1500, Nome = "Notebook"       },
            new Produto{Id = 3, Estoque = 10, Valor = 4000, Nome = "Playstation 5"  },
            new Produto{Id = 4, Estoque = 10, Valor = 2000, Nome = "Nintendo Switch"},
            new Produto{Id = 5, Estoque = 10, Valor = 6000, Nome = "Tablet"}
            };
        public List<Produto> GetAllProdutos()
        {
            return listaProdutos;
        }
    }
}
