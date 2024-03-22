using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess;
using Oracle.EntityFrameworkCore;
using Commerce.Application;
using Commerce.Application.Services;
using Commerce.Infrastructure;
using Commerce.Infrastructure.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CommerceDBContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection") ?? throw new InvalidOperationException("String de conex�o inv�lida")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoService,ProdutoService>();
builder.Services.AddScoped<IProdutoRepository,ProdutoRepository>();
builder.Services.AddScoped<OracleDatabaseService>();

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

app.Run();
