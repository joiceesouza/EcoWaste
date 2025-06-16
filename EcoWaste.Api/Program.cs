using EcoWaste.Business.Interfaces;
using EcoWaste.Business.Services;
using EcoWaste.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container
builder.Services.AddControllers(); // Habilita suporte a controllers
builder.Services.AddEndpointsApiExplorer();

// Swagger configurado corretamente
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoWaste API", Version = "v1" });
});

// 2. Configuração do banco de dados
builder.Services.AddDbContext<EcoTrackDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Injeção de dependências
builder.Services.AddScoped<IColetaService, ColetaService>();
builder.Services.AddScoped<IResiduoService, ResiduoService>();
builder.Services.AddScoped<IPontoColetaService, PontoColetaService>();


var app = builder.Build();

// 4. Configure middleware do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoWaste API v1"));
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
