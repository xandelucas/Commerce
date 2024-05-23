using Commerce.Infrastructure.Data;

namespace Commerce.API;

public class SeedHostedService : IHostedService
{
    private readonly IServiceProvider _sp;

    public SeedHostedService(IServiceProvider sp)
    {
        _sp = sp;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var scope = _sp.CreateScope();
        var database = scope.ServiceProvider.GetRequiredService<CommerceDBContext>();
        if (!database.Categorias.Any())
        {
            database.Categorias.Add(new Domain.Categoria("Acessórios","Acessórios"));
            database.Categorias.Add(new Domain.Categoria("Telefonia","Telefonia"));
            database.Categorias.Add(new Domain.Categoria("TV","TV"));
            database.Categorias.Add(new Domain.Categoria("Videogame","VideoGame"));
            await database.SaveChangesAsync(cancellationToken);
        }
        if (!database.Produto.Any())
        {
            database.Produto.Add(new Domain.Produto("Copo Stanley 483 Ml", 10, 3, true, 1));
            database.Produto.Add(new Domain.Produto("Tablet  Redmi 12 Pad", 1200, 100, true, 2));
            database.Produto.Add(new Domain.Produto("TV Samsung 50'", 1800, 50, true, 3));
            database.Produto.Add(new Domain.Produto("Nintendo Switch OLED", 1900, 50, true, 4));
            database.Produto.Add(new Domain.Produto("Playstation 5", 4200, 30, false, 4));
            await database.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

