

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Domain.Interfaces;
using Portifolio.Infra.Data.Context;
using Portifolio.Infra.Data.Interfaces;
using Portifolio.Infra.Data.Repositories;

namespace Portifolio.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(opt =>
            opt.UseInMemoryDatabase("portifolio"));


            //conexão com o banco de dados
            //var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            //builder.Services.AddDbContext<DBContext>(option => option.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));

            services.AddScoped<IPessoa, PessoaRepository>();
            services.AddScoped<IProjeto, ProjetoRepository>();

            services.AddSingleton<IElementoRepository, ElementoRepository>();
            
            
            return services;
        }
    }
}
