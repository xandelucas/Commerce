using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Commerce.Application.DTOs;

public class ProdutoDTO
{
    [JsonIgnore]
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int Estoque { get; set; }
    [JsonIgnore]
    public DateTime DataCadastroUtc { get;  set; }
    [JsonIgnore]
    public DateTime DataAtualizacaoUtc { get;  set; }
    public bool Status { get;  set; } 
    public int CategoriaId { get; set; }
}
