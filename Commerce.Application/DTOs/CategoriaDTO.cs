using System.Text.Json.Serialization;

namespace Commerce.Application.DTOs;

public class CategoriaDTO
{
    [JsonIgnore]
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime DataCriacaoUtc { get; set; } = DateTime.UtcNow;
    [JsonIgnore]
    public DateTime DataAtualizacaoUtc { get; set; }
}
