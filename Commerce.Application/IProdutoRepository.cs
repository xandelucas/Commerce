using Commerce.Domain;
using System.Collections.Generic;

namespace Commerce.Application
{
    public interface IProdutoRepository
    {
        List<Produto> GetAllProdutos();
    }
}
