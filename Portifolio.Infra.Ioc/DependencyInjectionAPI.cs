

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portifolio.Application.Mappings;
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
            //var connectionStringMysql = configuration.GetConnectionString("ConnectionMysql");
            //services.AddDbContextPool<DBContext>(option => option.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));

            services.AddScoped<IPessoa, PessoaRepository>();
            services.AddScoped<IProjeto, ProjetoRepository>();

            services.AddSingleton<IElementoRepository, ElementoRepository>();

            //automapper
            services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            return services;
        }
    }
}
