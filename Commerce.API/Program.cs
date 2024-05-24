using Microsoft.EntityFrameworkCore;
using Commerce.Application;
using Commerce.Application.Services;
using Commerce.Infrastructure.Data;
using Commerce.Infrastructure.Interfaces;
using Commerce.API;
using Commerce.Application.Mapper;
using Commerce.Domain;
using Microsoft.AspNetCore.Diagnostics;
using BancoApp.API;
using FluentValidation;
using Commerce.Application.IServices;
using Commerce.Infrastructure.Repositorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.IncludeXmlComments(Path.Join(AppContext.BaseDirectory, "Commerce.API.xml"));
});

builder.Services.AddDbContext<CommerceDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SQLServer") ?? throw new InvalidOperationException("String de conexão inválida")));


builder.Services.AddHostedService<SeedHostedService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IRepository<Categoria>, Repository<Categoria>>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(CommerceMapping));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is DomainException domainException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
            await context.Response.WriteAsJsonAsync(
                new ApiRetorno { Mensagem = domainException.Message }
            );
            return;
        }

        if (exceptionHandlerPathFeature?.Error is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
            await context.Response.WriteAsJsonAsync(
                new ApiRetorno
                {
                    Mensagem = "Houve erros de validação",
                    Erros = validationException
                        .Errors.GroupBy(x => x.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray())
                }
            );
            return;
        }

        return;
    });
});

using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<CommerceDBContext>();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

app.Run();
