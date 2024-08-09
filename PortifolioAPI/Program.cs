


using Portifolio.Infra.Ioc;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

//Chamo o m�todo est�tico com as configs do banco e as inje��es de depend�ncia
builder.Services.AddInfrastructureAPI(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
//builder.Services.AddDbContext<DBContext>(option => option.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


