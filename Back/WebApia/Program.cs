using System.Diagnostics;
using Ellp.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using Ellp.Api.Infra.SqlServer.Repository;
using Ellp.Api.Infra.SqlServer;
using Ellp.Api.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var isInContainer = builder.Environment.IsEnvironment("Docker");

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Oficina 2", Version = "v1" });
});


builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Ellp.Api.Application.UseCases.GetLoginUseCases.GetLoginStudent.GetLoginStudentUseCase).Assembly,
    typeof(Ellp.Api.Application.UseCases.GetLoginUseCases.GetLoginProfessor.GetLoginProfessorUseCase).Assembly
));

//Merda do cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", policy =>
    {
        policy.WithOrigins("https://localhost:7172")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Oficina 2 v1"));
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

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

            Console.WriteLine($"Erro ao abrir o navegador: {ex.Message}");
        }
    });
}

app.Run();

