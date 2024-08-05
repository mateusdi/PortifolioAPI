

using Microsoft.EntityFrameworkCore;
using PortifolioAPI.infrastructure;
using PortifolioAPI.Interfaces;
using PortifolioAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexão com o banco de dados
//var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
//builder.Services.AddDbContext<DBContext>(option=> option.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));


//Contexto usando o banco em memória, para desenvolvimento.
builder.Services.AddDbContext<DBContext>(opt =>
    opt.UseInMemoryDatabase("portifolio"));

//definindo a injeção de dependecia do repositório Pessoa
//builder.Services.AddTransient<IPessoa, PessoaRepository>();

//DI da interface generica
//builder.Services.AddTransient<IGenerica<Projeto>, GenericoRepository<Projeto>>();
builder.Services.AddScoped(typeof(IGenerica<>), typeof(GenericoRepository<>));

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
