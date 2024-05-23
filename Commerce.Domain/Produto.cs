using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Domain;


public class Produto
{
    public long Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public decimal Valor { get; private set; }
    public int Estoque{ get; private set; }
    public DateTime DataCadastroUtc { get; private set; }
    public DateTime DataAtualizacaoUtc { get; private set; }
    public bool Status { get; private set; } 
    public long CategoriaId { get; private set; } 
    public Produto(string nomeDoProduto, decimal valorDoProduto, int estoqueDoProduto, bool statusDoProduto, int categoriaDoProduto ) 
    {
        Nome = nomeDoProduto.Trim();
        Valor = valorDoProduto;
        Estoque = estoqueDoProduto;
        Status = statusDoProduto;
        DataCadastroUtc = DateTime.UtcNow;
        DataAtualizacaoUtc = DateTime.UtcNow;
        CategoriaId = categoriaDoProduto;  
        ValidaEstoque();
        ValidaValor();
    }
    public void AjustaValor(decimal valorDoProduto)
    {
        Valor = valorDoProduto;
        ValidaValor();
    }
    public void AjustaEstoque(int estoqueDoProduto)
    {
        Estoque = estoqueDoProduto;
        ValidaEstoque();
    }
    public void AjustaDataAtualizacao()
    {
        DataAtualizacaoUtc = DateTime.UtcNow;
    }
    private void ValidaValor()
    {
        if (Valor < 0)
        {
            throw new ArgumentException(
                "O valor do produto não pode ser negativo",
                nameof(Valor)
            );
        }
    }
    private void ValidaEstoque()
    {
        if (Estoque < 0)
        {
            throw new ArgumentException(
                "O estoque do produto não pode ser negativo",
                nameof(Estoque)
            );
        }
    }

    private Produto() {
        ValidaEstoque();
        ValidaValor();
    }
}
