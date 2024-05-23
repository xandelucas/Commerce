namespace Commerce.Domain;

public class ListaPaginada<T>
{
    public int Pagina { get; init; }
    public int Paginas { get; init; }
    public int Total { get; init; }
    public int TamanhoPagina { get; }

    public List<T> Itens { get; init; }

    public ListaPaginada(List<T> itens, int total, int pagina, int tamanhoPagina)
    {
        Pagina = pagina;
        Paginas = tamanhoPagina == -1 ? 1 : (int)Math.Ceiling((double)total / tamanhoPagina);
        Total = total;
        Itens = itens;
        TamanhoPagina = tamanhoPagina == -1 ? total : tamanhoPagina;
    }
}

public class ConfiguracaoPaginacao
{
    public int Pagina
    {
        get => pagina;
        set => pagina = value < 1 ? 1 : value;
    }

    private int pagina = 1;

    public int TamanhoPagina
    {
        get => tamanhoPagina;
        set => tamanhoPagina = Math.Clamp(value, -1, 50);
    }

    private int tamanhoPagina = 10;
}
