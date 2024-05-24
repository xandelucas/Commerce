using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Domain;

public class Categoria
{
    public long Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public DateTime DataCriacaoUtc { get; private set; } = DateTime.UtcNow;
    public DateTime DataAtualizacaoUtc { get; private set; }

    private Categoria() { }
    public Categoria(string nomeDaCategoria, string descricaoDaCategoria)
    {
        Nome = nomeDaCategoria.Trim();
        Descricao = descricaoDaCategoria.Trim();
        DataAtualizacaoUtc = DateTime.UtcNow;
    }

    public void AjustaDataAtualizacao(DateTime dataAtualizacao)
    {
        DataAtualizacaoUtc = DateTime.UtcNow;
    }
}
