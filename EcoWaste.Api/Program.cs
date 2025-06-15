using EcoWaste.Business.Interfaces;
using EcoWaste.Business.Services;
using EcoWaste.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container
builder.Services.AddControllers(); // Habilita suporte a controllers

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Suporte ao Swagger

// 2. Configuração do banco de dados
builder.Services.AddDbContext<EcoTrackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // substitua com Oracle se for usar Oracle

// 3. Injeção de dependências
builder.Services.AddScoped<IColetaService, ColetaService>();
builder.Services.AddScoped<IResiduoService, ResiduoService>();
builder.Services.AddScoped<IPontoColetaService, PontoColetaService>();

var app = builder.Build();

// 4. Configure middleware do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // obrigatório se você for usar autenticação/autorização

app.MapControllers(); // Habilita os endpoints dos controllers

app.Run();
