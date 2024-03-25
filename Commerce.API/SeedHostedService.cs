
using Commerce.Infrastructure.Data;

namespace Commerce.API
{
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
            if (!database.Produto.Any())
            {
                database.Produto.Add(new Domain.Produto()
                {
                    Nome = "Copo",
                    Valor = 10,
                    Estoque = 10,
                });
                database.Produto.Add(new Domain.Produto()
                {
                    Nome = "Tablet",
                    Valor = 1200,
                    Estoque = 100,
                });
                database.Produto.Add(new Domain.Produto()
                {
                    Nome = "TV",
                    Valor = 1800,
                    Estoque = 50,
                });
                database.Produto.Add(new Domain.Produto()
                {
                    Nome = "Nintendo Switch",
                    Valor = 2200,
                    Estoque = 100,
                });
                database.Produto.Add(new Domain.Produto()
                {
                    Nome = "Playstation 5",
                    Valor = 4200,
                    Estoque = 30,
                });
                await database.SaveChangesAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

