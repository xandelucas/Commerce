namespace BancoApp.API;

public class ApiRetorno
{
    public string Mensagem { get; init; } = string.Empty;

    public Dictionary<string, string[]>? Erros { get; set; }
}
