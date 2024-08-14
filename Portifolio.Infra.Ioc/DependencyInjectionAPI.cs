

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Portifolio.Application.Mappings;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;

using Portifolio.Infra.Data.Repositories;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Portifolio.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DBContext>(opt =>
            //opt.UseInMemoryDatabase("portifolio"));

            var connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

            //conexão com o banco de dados
            //var connectionStringMysql = configuration.GetConnectionString("ConnectionMysql");
            //services.AddDbContextPool<DBContext>(option => option.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));

            services.AddScoped<IPessoa, PessoaRepository>();
            services.AddScoped<IProjeto, ProjetoRepository>();

            //services.AddSingleton<IElementoRepository, ElementoRepository>();

            //automapper
            services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            return services;
        }
    }
}
