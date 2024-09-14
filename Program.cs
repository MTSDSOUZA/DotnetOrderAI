using DotnetOrderAI.Data;
using DotnetOrderAI.Repository;
using DotnetOrderAI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<dbContext>(options =>
options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(optopns =>
{
    optopns.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto de conclusão Challenge FIAP 2024 - 2º Semestre",
        Description = "API criada pelo time Solution Developers para o app chamado OrderAI",
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 1",
            Email = "pf1954@fiap.com.br",
            Url = new Uri("https://www.linkedin.com/in/pelego-numero1"),
        },
    });

    // Adicionando mais contatos
    optopns.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Contato Adicional",
        Description = "Contato 2",
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 2",
            Email = "pelego2@fiap.com.br",
            Url = new Uri("https://www.linkedin.com/in/pelego-numero2"),
        }
    });

    optopns.SwaggerDoc("v3", new OpenApiInfo
    {
        Version = "v3",
        Title = "Contato Adicional",
        Description = "Contato 3",
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 3",
            Email = "pelego3@fiap.com.br",
            Url = new Uri("https://www.linkedin.com/in/pelego-numero3"),
        }
    });

    optopns.SwaggerDoc("v4", new OpenApiInfo
    {
        Version = "v4",
        Title = "Contato Adicional",
        Description = "Contato 4",
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 4",
            Email = "pelego4@fiap.com.br",
            Url = new Uri("https://www.linkedin.com/in/pelego-numero4"),
        }
    });

    optopns.SwaggerDoc("v5", new OpenApiInfo
    {
        Version = "v5",
        Title = "Contato Adicional",
        Description = "Contato 5",
        Contact = new OpenApiContact
        {
            Name = "Pelego Numero 5",
            Email = "pelego5@fiap.com.br",
            Url = new Uri("https://www.linkedin.com/in/pelego-numero5"),
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    optopns.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.InjectStylesheet("/swagger-ui/custom.css");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
