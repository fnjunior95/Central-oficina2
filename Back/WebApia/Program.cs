using System.Diagnostics;
using ellp.api.infra.sqlserver;
using Ellp.Api.Application.Interfaces;
using Ellp.Api.Infra.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Carregar User Secrets em ambiente de desenvolvimento
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var isInContainer = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker";

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    if (isInContainer)
    {
        serverOptions.ListenAnyIP(80);
    }
    else
    {
        serverOptions.ListenLocalhost(5000);
    }
});

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication5", Version = "v1" });
});

// Utilizar a Connection String correta a partir dos User Secrets
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

// Obter a Connection String para verificação (temporário)
var dba = builder.Configuration.GetConnectionString("DbConnectionString");

if (builder.Environment.IsDevelopment())
{
    // Temporariamente logar a Connection String (apenas para verificação)
    Console.WriteLine($"Connection String: {dba}");
}

// Registro dos Repositórios
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://seu-frontend.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurações do Middleware
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication5 v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

// Configurar middleware CORS antes de MapControllers
app.UseCors("AllowedOrigins");

app.MapControllers();

if (!isInContainer)
{
    var url = "http://localhost:5000/swagger";
    Task.Run(() =>
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "msedge",
                Arguments = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            // Opcional: Logar ou tratar a exceção conforme necessário
            Console.WriteLine($"Erro ao abrir o navegador: {ex.Message}");
        }
    });
}

app.Run();
