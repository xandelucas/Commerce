using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application
{
    public interface IProdutoService
    {
        List<Produto> GetAllProdutos();
    }
}
