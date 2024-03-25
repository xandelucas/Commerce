using Microsoft.EntityFrameworkCore;
using Commerce.Application;
using Commerce.Application.Services;
using Commerce.Infrastructure;
using Commerce.Infrastructure.Data;
using Commerce.Infrastructure.Interfaces;
using Commerce.API;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Commerce.Application.Mapper;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommerceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer") ?? throw new InvalidOperationException("String de conexão inválida")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.IncludeXmlComments(Path.Join(AppContext.BaseDirectory, "Commerce.API.xml"));
});
builder.Services.AddHostedService<SeedHostedService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(ProdutoMapping));


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
